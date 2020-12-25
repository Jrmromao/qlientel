import axios, { AxiosResponse } from "axios";
import { IUser, IUserFormValues, IRole } from "../models/usersModels/user";
import { history } from "../..";
import { toast } from "react-toastify";
import {
  IEmployeeFormValues,
  IEmployeeData,
  IDepartment,
  IEmployeeDetails,
  IAddEmployeeValues,
  IDocuments,
} from "../models/employeeModels/employee";
import { IAddSubmitCompany, ICompany } from "../models/companyModels/ICompany";
import { IOffice, IOfficeList } from "../models/companyModels/IOffices";
import {
  IJobTitle,
  IJobTitleItemList,
  ISchedulePolicy,
  ISchedulePolicyItemList,
} from "../models/commonModels/companyPolicies";
import { ILeaves, ILeavesRequest } from "../models/employeeModels/leaves";
import { ICustomer } from "../models/customerModels/customer";
// default
axios.defaults.baseURL = process.env.REACT_APP_API_URL;



axios.interceptors.request.use(
  (config) => {
    const token = window.localStorage.getItem("jwt");
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

axios.interceptors.response.use(undefined, (error) => {
  if (error.message === "Network Error" && !error.response) {
    toast.error("Network error - make sure API is running!");
  }
  const { status, data, config, headers } = error.response;
  if (status === 404) {
    history.push("/ups");
  }
  if (
    status === 401 &&
    headers["www-authenticate"] ===
      'Bearer error="invalid_token", error_description="The token is expired"'
  ) {
    window.localStorage.removeItem("jwt");
    history.push("/");
    toast.info("Your session has expired, please login again");
  }
  if (
    status === 400 &&
    config.method === "get" &&
    data.errors.hasOwnProperty("id")
  ) {
    history.push("/ups");
  }
  if (status === 500) {
    toast.error("Server error - check the terminal for more info!");
  }
  throw error.response;
});

const responseBody = (response: AxiosResponse) => response.data;

/**
 * only manager will be abe to see the employees docs and personal information
 * maybe department manager wont be able to see bank details - need to discuss this
 *
 * */

const request = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
  employeeForm: (url: string, values: IAddEmployeeValues) => {
    var formData = new FormData();
    formData.append("departmentId", values.departmentId);
    formData.append("email", values.email);
    formData.append("firstName", values.firstName);
    formData.append("lastName", values.lastName);
    formData.append("reportsTo", values.reportsTo);
    formData.append("role", values.role);
    formData.append("salary", values.salary.toString());
    formData.append("schedulePolicy", values.schedulePolicy);
    //formData.append("startingDate", values.startingDate.toString());
    formData.append("title", values.title);
    formData.append("contractDoc", values.contractDoc[0]);

    return axios
      .post(url, formData, {
        headers: { "Content-type": "multipart/form-data" },
      })
      .then(responseBody);
  },
};

// all the methods to support the user functionality
const user = {
  Current: (): Promise<IUser> => request.get("/user/current-user"),
  login: (data: IUserFormValues): Promise<IUser> =>
    request.post("/user/login", data),
  register: (data: IUserFormValues) => request.post("/account/register", data),
  //retrieve docs
  //submit docs
  //remove doc
};

//load non basic users - admin & managers
const nonBasicUsers = {
  list: (companyId: string): Promise<IUser[]> =>
    request.get(`system/get-non-basic-users/${companyId}`),
};

const employee = {
  getDetails: (employeeId: string): Promise<IEmployeeData> =>
    request.get(`/employee/get-details/${employeeId}`),
  create: (data: IAddEmployeeValues) =>
    request.employeeForm("/employee/add-employee", data),
  update: (employeeId: string, data: IEmployeeFormValues) =>
    request.put(`/employee/update-employee/${employeeId}`, data),
  search: (data: string): Promise<IEmployeeFormValues[]> =>
    request.get(`/employee/search/${data}`),
};

const department = {
  create: (data: IDepartment) => request.post(`/admin/add-department/`, data),
  find: (departmentId: string): Promise<IDepartment> =>
    request.get(`/managerProfile/department/${departmentId}`),
  update: (departmentId: string, data: IOffice) =>
    request.put(`/admin/update-department-details/${departmentId}`, data),
  findAll: (officeId: string): Promise<IDepartment[]> =>
    request.get(`/system/get-departments-by-office/${officeId}`),
};

const office = {
  create: (data: IOffice) => request.post("/admin/add-office", data),
  update: (officeId: string, data: IOffice) =>
    request.put(`/admin/update-office-details/${officeId}`, data),
  find: (officeId: string): Promise<IOffice[]> =>
    request.get(`/admin/get-office-details/${officeId}`),
  getAll: (employeeID: string): Promise<IOfficeList[]> =>
    request.get(`/system/get-offices/${employeeID}`),
};

const company = {
  create: (data: IAddSubmitCompany) =>
    request.post("/company/add-company", data),
  find: (employeeId: string): Promise<ICompany> =>
    request.get(`/admin/get-company-details/${employeeId}`),
  listEmployees: (companyId: string): Promise<IEmployeeDetails[]> =>
    request.get(`/admin/get-company-employees/${companyId}`),
};

const search = {
  employee: (query: string, companyId: string): Promise<IEmployeeDetails[]> =>
    request.get(`/search/search-employee/${companyId}/${query}`),
};

const schedulePolicy = {
  create: (data: any): Promise<AxiosResponse> =>
    request.post(`/system/create-schedule-policy`, data),
  update: (schedulePolicyId: string, data: any): Promise<AxiosResponse> =>
    request.put(`/system/create-schedule-titles/${schedulePolicyId}`, data),
  get: (jobTitleId: string): Promise<ISchedulePolicy> =>
    request.get(`/system/get-job-titles/${jobTitleId}`),
  list: (companyId: string): Promise<ISchedulePolicyItemList[]> =>
    request.get(`/system/list-schedule-policy/${companyId}`),
};

const jobTitle = {
  create: (data: any): Promise<AxiosResponse> =>
    request.post(`/system/create-job-titles`, data),
  edit: (jobTitleId: string, data: IJobTitle): Promise<AxiosResponse> =>
    request.put(`/system/create-job-titles/${jobTitleId}`, data),
  list: (companyId: string): Promise<IJobTitleItemList[]> =>
    request.get(`/system/list-job-titles/${companyId}`),
  get: (jobTitleId: string): Promise<IJobTitle> =>
    request.get(`/system/get-job-titles/${jobTitleId}`),
};

const expenseClaim = {};

const leaves = {
  request: (data: ILeavesRequest): Promise<AxiosResponse> =>
    request.post("/employee/leave-request", data),
  list: (employeeId: string): Promise<ILeaves> =>
    request.get(`/employee/get-leaves-data/${employeeId}`),
};

const roles = {
  list: (): Promise<IRole[]> => request.get("/system/get-roles"),
};

const customer = {
  create: (data: ICustomer): Promise<AxiosResponse> =>
    request.post(`/customer/crate-customer`, data),
  update: (customerId: string, data: ICompany): Promise<AxiosResponse> =>
    request.put(`/customer/update-customer-details/${customerId}`, data),
  list: (companyId: string): Promise<ICustomer[]> =>
    request.get(`/customer/list-customers/${companyId}`),
  // customer documents
  listCustomerDocs: (customerId: string): Promise<IDocuments[]> =>
    request.get(`/customer/list-customers-documents/${customerId}`),

};

export default {
  customer,
  expenseClaim,
  leaves,
  employee,
  jobTitle,
  schedulePolicy,
  user,
  company,
  department,
  office,
  search,
  roles,
  nonBasicUsers,
};

// import { IAddress } from "../commonModels/IAddress";

import { IEmployeeData, IEmployeeDetails } from "../employeeModels/employee";

// user login
export interface IUser {
  id: string;
  email: string;
  displayName: string;
  username: string;
  token: string;
  image?: Blob;
  role: string[];
  department: string
  //employee details
  departmentId: string;
  employeeId: string;
  companyId: string
  company: string
}
export interface IRole {
  role: string;
}
export interface IUserFormValues {
  // for now, i'll request very little info for to register, but in the future, we need to collect more details.
  // such as: professional number, etc...
  name?: string;
  password: string;
  email: string;

}





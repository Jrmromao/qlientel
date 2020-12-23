import { RootStore } from "./rootStore";
import { observable, action, runInAction, ObservableMap } from "mobx";
import {
  IDepartment,
  IEmployeeDetails,
} from "../models/employeeModels/employee";
import agents from "../API/agents";
import { IUser } from "../models/usersModels/user";
 

export default class ManageEmployeeStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }
  @observable departmentData: IDepartment | null = null;
  @observable employeesData: IEmployeeDetails[] = [];

  @action loadEmployeesData = async (user: IUser) => {

    


    try {
    //   if (user.role[0] !== "Manager") {
    //     let departmentData = await agents.department.find(user.companyId);
    //     if (departmentData != null)
    //       runInAction(() => {
    //         this.departmentData = departmentData;
    //       });
    //   }
    //   // run the admin method to get all the employees in the company
    //   else {
    // console.log(user);

        let employeesData = await agents.company.listEmployees(user.companyId);

        if (employeesData)
          runInAction(() => {
            this.employeesData = employeesData;
          });
     // }
    } catch (error) {
      throw error;
    }
  };
}

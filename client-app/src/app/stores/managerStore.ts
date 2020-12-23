import { RootStore } from "./rootStore";
import { observable, action, runInAction } from "mobx";
import { IDepartment } from "../models/employeeModels/employee";
import agents from "../API/agents";
import { IUser } from "../models/usersModels/user";

export default class ManagerStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable tabIndex: string = "0";
  @observable departmentData: IDepartment | null = null

  @action ChangeTab = async (tabSelected: string) => {
    runInAction(() => {
      this.tabIndex = tabSelected;
    });
  };

  @action loadDepartmentData = async (user: IUser) => {
    try {


      if(user.role[0] === 'Manager')
          var department = await agents.department.find(user.departmentId);

      else 
// run the admin method to get all the employees in the c


        runInAction(() => {
            this.departmentData = department;
          });   
        } catch (error) {
      throw error;
    }
  };
}

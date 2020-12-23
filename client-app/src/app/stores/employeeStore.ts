import { RootStore } from "./rootStore";
import { observable, action, runInAction } from "mobx";
import {
  IEmployeeFormValues,
  EmployeeFormValues,
  IAddEmployeeValues,
} from "../models/employeeModels/employee";
import agents from "../API/agents";
import { IRole } from "../models/usersModels/user";

export default class EmployeeStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable tabIndex: string = "0";
  @observable stackButtons: boolean = false;
  @observable userRoles: IRole[] = [];
  @observable contractFile: Blob[] = [];
  @observable startDate: Date = new Date();

  @observable employee: EmployeeFormValues | null = null;

  @action setContractFile = async (file: any) => {
    this.contractFile = file;
  };

  @action loadUserRole = async () => {
    try {
      const data = await agents.roles.list();

      if (data)
        runInAction(() => {
          this.userRoles = data;
        });
    } catch (error) {
      throw error;
    }
  };
  @action SetStartDate = async (newDate: Date) => {
    runInAction(() => {
      this.startDate = newDate;
    });
  };
  @action loadMyData = async (employeeID: string) => {
    try {
      let employee: any = await agents.employee.getDetails(employeeID);
      if (employee)
        runInAction(() => {
          this.employee = employee;
        });
      return employee;
    } catch (error) {
      throw error;
    }
  };
  @action ChangeTab = async (tabSelected: string) => {
    runInAction(() => {
      this.tabIndex = tabSelected;
    });
  };
  @action UpdateEmployeeDetails = async (
    employeeId: string,
    formValues: IEmployeeFormValues
  ) => {
    try {
      const result = await agents.employee.update(employeeId, formValues);
      if (result) this.rootStore.userStore.getUser();
    } catch (error) {
      throw error;
    }
  };
  @action SubmitEmployeeDetails = async (data: IAddEmployeeValues) => {
    try {




      data.contractDoc = this.contractFile;

      console.log(data);

     await agents.employee.create(data);
    } catch (error) {
      throw error;
    }
  };
}

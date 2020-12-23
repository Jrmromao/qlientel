import { RootStore } from "./rootStore";
import { observable, action, runInAction } from "mobx";
import agents from "../API/agents";
import { IOffice, IOfficeList } from "../models/companyModels/IOffices";
import { IDepartment } from "../models/employeeModels/employee";
import { IAddress } from "../models/commonModels/IAddress";

export default class OfficeStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }
  @observable isMainHQ: boolean = false;
  @observable officeList: IOfficeList[] = [];
  @observable departmentList: IDepartment[] = [];
  @observable officeAddress: IAddress | null = null;
  @action mainHQChange = () => {
    this.isMainHQ = !this.isMainHQ;
  };
  @action loadDepartments = async (officeId: string) => {
    try {
      const departments = await agents.department.findAll(officeId);
      if (departments) {
        runInAction(() => {
          this.departmentList = departments;
        });
      }
    } catch (error) {
      throw error;
    }
  };

  @action createOffice = async (data: IOffice) => {
    try {
 
 

      data.isMainHR = this.isMainHQ;

     const response = await agents.office.create(data);
    } catch (error) {
      throw error;
    }
  };
  @action
  resetDepartmentList = async () =>
    runInAction(() => {
      this.departmentList = [];
    });

  @action loadOffices = async () => {
    try {
      let result = await agents.office.getAll(
        this.rootStore.userStore.user?.employeeId!
      );
      if (result) {
        runInAction(() => {
          this.officeList = result;
        });
      }
    } catch (error) {}
  };

  // department methods
  @action creatDepartment = async (data: IDepartment) => {
    try {
      console.log(data);

      const result = await agents.department.create(data);
    } catch (error) {
      throw error;
    }
  };
}

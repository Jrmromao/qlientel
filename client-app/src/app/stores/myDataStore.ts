import { RootStore } from "./rootStore";
import { observable, action, runInAction } from "mobx";
// import { IEmployeeFormValue } from "../models/employeeModels/employee";
// import agents from "../API/agents";

export default class MyDataStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable readOnlyFlag: boolean = false;

  @action setEditTrue = async () => {
    runInAction(() => {
      this.readOnlyFlag = !this.readOnlyFlag;
    });
  };

  
  @action SageChanges = async () => {
    runInAction(() => {
      this.readOnlyFlag = !this.readOnlyFlag;

    });
  };
}

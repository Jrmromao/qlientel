import { action, observable, ObservableMap, runInAction } from "mobx";
import agents from "../API/agents";
import { ILeaves, ILeavesRequest } from "../models/employeeModels/leaves";
import { RootStore } from "./rootStore";

export default class LeavesStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable leavesData: ILeaves | null = null;
  @observable dateError: string = "";

  @action loadLeavesData = async (employeeID: string) => {
    try {
      const result = await agents.leaves.list(employeeID);

      if (result) {
        runInAction(() => {
          this.leavesData = result;
        });
      }
    } catch (error) {
      throw error;
    }
  };

  @action requestLeave = async (data: ILeavesRequest) => {
    try {
      const user = this.rootStore.userStore.user;
      data.employeeId = user?.employeeId!;
      if (data.toDate < data.fromDate)
        throw new Error(
          (this.dateError = "Date to cannot be before date from!")
        );

      await agents.leaves.request(data);
    } catch (error) {
      throw error;
    }
  };
}

import { RootStore } from "./rootStore";
import { observable, action, runInAction } from "mobx";
import {
  IJobTitle,
  IJobTitleItemList,
  ISchedulePolicy,
  ISchedulePolicyItemList,
} from "../models/commonModels/companyPolicies";
import agents from "../API/agents";

export default class PolicyStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }
  @observable jobTitleOptions: IJobTitleItemList[] = [];
  @observable schedulePolicyOptions: ISchedulePolicyItemList[] = [];
  // add - job title
  @action submitJobTitle = async (data: IJobTitle) => {
    try {
      const result = await agents.jobTitle.create(data);
    } catch (error) {
      throw error;
    }
  };
  //update - job title
  @action updateJobTitle = async (titleId: string, data: IJobTitle) => {
    try {
      const result = await agents.jobTitle.edit(titleId, data);
    } catch (error) {
      throw error;
    }
  };
  //get - job title
  @action getJobTitle = async (titleId: string) => {
    try {
      const result = await agents.jobTitle.get(titleId);
      console.log(result);
    } catch (error) {
      throw error;
    }
  };
  //list - job title
  @action listJobTitles = async (companyId: string) => {
    try {

      console.log(companyId);
      
      const result = await agents.jobTitle.list(companyId);
      if (result)
        runInAction(() => {
          this.jobTitleOptions = result;
        });
    } catch (error) {
      throw error;
    }
  };

  // schedule policy
  //add
  @action submitSchedulePolicy = async (data: ISchedulePolicy) => {
    console.log(data);

    const response = await agents.schedulePolicy.create(data);
  };
  //get
  @action getSchedulePolicy = async () => {};
  //update
  @action updateSchedulePolicy = async () => {};
  //list
  @action listSchedulePolicy = async (companyId: string) => {
    try {
      const response = await agents.schedulePolicy.list(companyId);

      if (response) {
        runInAction(() => {
          this.schedulePolicyOptions = response;
        });
      }
    } catch (error) {
      throw error;
    }
  };
}

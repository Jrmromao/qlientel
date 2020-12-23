import { RootStore } from "./rootStore";
import { observable, action, runInAction } from "mobx";
import agents from "../API/agents";
import { ICompany } from "../models/companyModels/ICompany";
import { IUser } from "../models/usersModels/user";

export default class AdminStore {
  rootStore: RootStore;
  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable company: ICompany | null = null;
  @observable managersList: IUser[] = [];

  @action GetCompanyDetail = async (employeeId: string) => {
    try {
      const companyData = await agents.company.find(employeeId);
      if (companyData) {
        runInAction(() => {
          this.company = companyData;
        });
      }
    } catch (error) {}
  };

  @action GetNonBasicUsers = async (companyId: string) => {
    try {
      const tempManagersList = await agents.nonBasicUsers.list(companyId);

      if (tempManagersList) {
        runInAction(() => {
          this.managersList = tempManagersList;
        });
      }
    } catch (error) {
      throw error;
    }
  };
}

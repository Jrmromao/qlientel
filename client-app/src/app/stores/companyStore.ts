import { RootStore } from "./rootStore";
import { action, runInAction, observable } from "mobx";
import agents from "../API/agents";
import {
  IAddFormDataCompany,
  IAddSubmitCompany,
} from "../models/companyModels/ICompany";

export default class CompanyStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable CompanyData: IAddSubmitCompany | null = null;

  @action autoStackButtonsDisplay = async (screenSize: number) => {
    if (screenSize < 700) runInAction(() => {});
    else runInAction(() => {});
  };

  @action SubmitCompanyDetails = async (data: IAddFormDataCompany) => {
    try {
      runInAction(() => {
        // this.CompanyData = {
        //   company: {
        //     name: data.companyName,
        //     phoneNumber: data.phoneNumber,
        //     fiscalNumber: data.fiscalNumber,
        //   },

        //   office: {
        //     officeName: data.officeName,
        //     code: data.code,
        //     address: {
        //       addressLine1: data.addressLine1,
        //       addressLine2: data.addressLine2,
        //       postCode: data.postCode,
        //       country: data.country,
        //       county: data.county,
        //     },
        //   },
        // };
      });

      let unit = await agents.company.create(this.CompanyData!);
      if (unit) console.log("Added");
    } catch (error) {
      throw error;
    }
  };
}

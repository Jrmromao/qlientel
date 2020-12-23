import { action, observable } from "mobx";
import agents from "../API/agents";
import { ICustomer } from "../models/customerModels/customer";
import { RootStore } from "./rootStore";

export default class CustomerStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable customer: ICustomer | null = null;
  @observable customerList: ICustomer[] = [];

  // add customer
  @action addCustomer = async (data: ICustomer) => {
    try {
      await agents.customer.create(data);
    } catch (ex) {
      console.log("Submitting Customer ERROR: ", ex);
    }
  };

  // list customer
  @action listCustomer = async (companyId: string) => {
    try {
      const customer = await agents.customer.list(companyId);
      if (customer) this.customerList = customer;
    } catch (ex) {
      console.log("Listing Customer ERROR: ", ex);
    }
  };


  
}

import { IAddress } from "../commonModels/IAddress";
import { IDocuments } from "../employeeModels/employee";

export interface ICustomer {
  companyId: string;
  name: string;
  email: string;
  pointOfContact: string;
  phoneNumber: string;
  documents: IDocuments[];
  dateRegistered: Date;
  address: IAddress
}


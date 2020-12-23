import { ICompany } from "./ICompany";
import { IAddress } from "../commonModels/IAddress";
import { IDepartment } from "../employeeModels/employee";

export interface IOffice {
  companyId?: string;
  officeName: string;
  code: string;
  departments?: IDepartment[]
  addressLine1: string;
  addressLine2: string;
  postCode: string;
  county: string;
  country: string;
  isMainHR: boolean
}



export interface IOfficeList{
  id: string
  value: string
  text: string
}
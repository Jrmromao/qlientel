import { IAddress } from "../commonModels/IAddress";
import { IOffice } from "./IOffices";

// export interface ICompany{
//     name: string
//     phoneNumber: string
//     offices?: IOffice[]
// }

export interface ICompany {
  id: string
  name: string;
  phoneNumber: string;
  fiscalNumber: string;
  office: IOffice[];
}


export interface IAddFormDataCompany {
  companyName: string;
  phoneNumber: string;
  fiscalNumber: string;
  addressLine1: string;
  addressLine2: string;
  postCode: string;
  county: string;
  country: string;
  officeName: string;
  code: string;
}





export interface IAddSubmitCompany {
  company: ICompany;
  office: IOffice;
}

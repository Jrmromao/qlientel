import { IAddress } from "../commonModels/IAddress";



export interface IAddEmployeeValues {
  departmentId: string
  email: string;
  firstName: string;
  lastName: string;
  reportsTo: string;
  role: string;
  salary: number;
  schedulePolicy: string;
  startingDate: Date;
  title: string;
  contractDoc: Blob[]
}


export interface IEmployeeFormValues {
  firstName: string;
  lastName: string;
  email: string;
  role: string;
  phoneNumber?: string;
  employeeDetails?: IEmployeeDetails;
}

export interface IEmployeeFormValuesSubmit {
  firstName: string;
  lastName: string;
  birthdayDate?: Date;
  sDate?: Date;
  email: string;
  role: string;
  phoneNumber?: string;
  pps?: string;
  salary?: number;
  address?: IAddress;
  bankDetails?: IBankDetails;
  department?: IDepartment;
  documents?: IDocuments[];
  //emergency contact
  Name: string;
  Relation: string;
}

export interface IEmployeeData {
  firstName: string;
  lastName: string;
  email: string;
  role: string;
  phoneNumber?: string;
  pps: string;
  salary: number;
  bDate?: Date;
  sDate?: Date;
  addressLine1: string;
  addressLine2: string;
  postCode: string;
  county: string;
  country: string;
  emergencyName: string;
  emergencyRelation: string;
  emergencyPhoneNumber: string;
  AccountNumber: string;
  SortCode: string;
  bic: string;
  iban: string;
}

export interface IAppUser{
  displayName:  string
  employeeDetailsId:  string
  firstName:  string
  lastName: string
  registerDate: Date
}


export interface IEmployeeDetails {
  appUser: IAppUser
  address: IAddress;
  bankDetails: IBankDetails;
  department: IDepartment;
  documents: IDocuments[];
  emergencyContact: IEmergencyContact;
  pps: string;
  salary: number;
  birthdayDate: Date;
  sDate: Date;
  role: string
}
export interface IEmergencyContact {
  Name: string;
  Relation: string;
  phoneNumber: string;
}
export interface IBankDetails {
  AccountNumber: string;
  SortCode: string;
  BIC: string;
  iban: string;
}


export interface IDepartment {
  Name: string;
  officeCode: string;
  employees: IEmployeeDetails[] | null;
}



export interface IDocuments {
  EmployeeDetailsId: string;
}

export class EmployeeFormValues implements IEmployeeData {
  firstName: string = "";
  lastName: string = "";
  email: string = "";
  role: string = "";
  phoneNumber: string = "";
  salary: number = 0;
  pps: string = "";
  bDate?: Date = undefined;
  sDate?: Date = undefined;
  addressLine1: string = "";
  addressLine2: string = "";
  postCode: string = "";
  county: string = "";
  country: string = "";
  emergencyName: string = "";
  emergencyRelation: string = "";
  emergencyPhoneNumber: string = "";
  AccountNumber: string = "";
  SortCode: string = "";
  bic: string = "";
  iban: string = "";

  constructor(init?: IEmployeeFormValues) {
    if (init) {

      Object.assign(this, init)      
    }
  }
}

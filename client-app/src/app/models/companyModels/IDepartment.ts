import { IUser } from "../usersModels/user";
import { IOffice } from "./IOffices";

export interface IDepartment {
name: string
managerId: IUser
phoneNumber: string
office: IOffice

}

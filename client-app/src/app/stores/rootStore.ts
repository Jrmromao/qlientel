import { createContext } from "react";
import UserStore from "./userStore";
import { configure } from "mobx";
import CommonStore from "./commonStore";
import ModalStore from "./modalStore";
import MenuBarStore from "./menuBarStore";
import EmployeeStore from "./employeeStore";
import CompanyStore from "./companyStore";
import TimeSheetStore from "./timeSheetStore";
import MyDataStore from "./myDataStore";
import ManagerStore from "./managerStore";
import AdminStore from "./adminStore";
import ManageEmployeeStore from "./manageEmployeeStore";
import OfficeStore from "./officeStore";
import PolicyStore from "./policyStore";
import LeavesStore from "./leavesStore";
import FinancesStore from './financesStore'
import CustomerStore from './customerStore'

configure({ enforceActions: "always" });
export class RootStore {
  customerStore: CustomerStore
  userStore: UserStore;
  commonStore: CommonStore;
  modalStore: ModalStore;
  menuBarStore: MenuBarStore;
  employeeStore: EmployeeStore;
  companyStore: CompanyStore;
  timeSheetStore: TimeSheetStore;
  myDataStore: MyDataStore;
  managerStore: ManagerStore;
  adminStore: AdminStore;
  manageEmployeeStore: ManageEmployeeStore
  officeStore: OfficeStore
  policyStore: PolicyStore
  leavesStore: LeavesStore
  expensesStore: FinancesStore;

  constructor() {
    this.customerStore = new CustomerStore(this)
    this.expensesStore = new FinancesStore(this)
    this.leavesStore = new LeavesStore(this)
    this.policyStore = new PolicyStore(this)
    this.manageEmployeeStore = new ManageEmployeeStore(this)
    this.officeStore = new OfficeStore(this)
    this.adminStore = new AdminStore(this)
    this.managerStore = new ManagerStore(this);
    this.myDataStore = new MyDataStore(this);
    this.timeSheetStore = new TimeSheetStore(this);
    this.companyStore = new CompanyStore(this);
    this.menuBarStore = new MenuBarStore(this);
    this.userStore = new UserStore(this);
    this.modalStore = new ModalStore(this);
    this.commonStore = new CommonStore(this);
    this.employeeStore = new EmployeeStore(this);
  }
}

export const RootStoreContext = createContext(new RootStore());

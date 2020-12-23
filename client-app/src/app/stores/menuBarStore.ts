import { RootStore } from "./rootStore";
import { observable, action, runInAction } from "mobx";

export default class MenuBarStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }
  @observable sideMenuVisible: boolean = false;
  @observable searchBarVisible: boolean = true;
  @observable employeeMenuItemVis: boolean = false;

  @action toggleSideMenu = async () =>
    runInAction(() => (this.sideMenuVisible = !this.sideMenuVisible));


    @action toggleEmployeeMenuItem = async () =>
    runInAction(() => (this.employeeMenuItemVis = !this.employeeMenuItemVis));



  @action autoToggleSideMenu = async (screenSize: number) => {
    if (screenSize < 700) {
      runInAction(() => (this.searchBarVisible = false));
      runInAction(() => (this.sideMenuVisible = true));
    } else {
      runInAction(() => (this.sideMenuVisible = false));
      runInAction(() => (this.searchBarVisible = true));
    }
  };
}

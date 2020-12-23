import { observable, computed, action, runInAction } from "mobx";
import { IUser, IUserFormValues } from "../models/usersModels/user";
import agents from "../API/agents";
import { RootStore } from "./rootStore";
import { history } from "../..";
import { IRegisterFormValues } from "../models/companyModels/company";

export default class UserStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable user: IUser | null = null;

  @computed get isLoggedIn() {
    return !!this.user;
  }

  @action Login = async (values: IUserFormValues) => {
    try {
      const user = await agents.user.login(values);
      runInAction(() => {
        this.user = user;
      });
      console.log("user after login: ", this.user);

      this.rootStore.commonStore.setToken(user.token);
      this.rootStore.modalStore.closeModal();


 
        history.push(`/${this.user?.role[0].toLowerCase()}/dashboard/`);

    } catch (error) {
      throw error;
    }
  };
  @action register = async (values: IRegisterFormValues) => {
    try { 
      const user = await agents.user.register(values);
      //this.rootStore.commonStore.setToken(user.token);
      this.rootStore.modalStore.closeModal();
      // history.push("/dashboard");
    } catch (error) {
      throw error;
    }
  };
  @action getUser = async () => {
    try {
      const user = await agents.user.Current();
      runInAction(() => {
        this.user = user;
      });
    } catch (error) {
      console.log(error);
    }
  };
  @action logout = () => {
    this.rootStore.commonStore.setToken(null);
    this.user = null;
    history.push("/");
  };
}

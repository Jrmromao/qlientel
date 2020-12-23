import { RootStore } from "./rootStore";
import { observable, action } from "mobx";

export default class ModalStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable.shallow modal = {
    open: false,
    body: null,
  };

  @action openModal = (content: any) => {
    this.modal.body = content;
    this.modal.open = true;
  };

  @action closeModal = () => {
    this.modal.body = null;
    this.modal.open = false;
  };


}

import { RootStore } from "./rootStore";
import { observable, action, runInAction } from "mobx";
// import { getDate } from "date-fns/esm";
import { getWeek, startOfWeek, addDays, endOfWeek, format } from "date-fns";

export default class TimeSheetStore {
  rootStore: RootStore;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable currentWeek: number = getWeek(Date.now());
  @observable weekDateRange: string[] = [];

  @action calculateDates = async () => {
    try {
      runInAction(() => {
        this.weekDateRange[0] = format(
          new Date(startOfWeek(Date.now())),
          "MM/dd"
        );
        this.weekDateRange[1] = format(
          new Date(addDays(startOfWeek(Date.now()), 1)),
          "MM/dd"
        );
        this.weekDateRange[2] = format(
          new Date(addDays(startOfWeek(Date.now()), 2)),
          "MM/dd"
        );
        this.weekDateRange[3] = format(
          new Date(addDays(startOfWeek(Date.now()), 3)),
          "MM/dd"
        );
        this.weekDateRange[4] = format(
          new Date(addDays(startOfWeek(Date.now()), 4)),
          "MM/dd"
        );
        this.weekDateRange[5] = format(
          new Date(addDays(startOfWeek(Date.now()), 5)),
          "MM/dd"
        );
        this.weekDateRange[6] = format(
          new Date(endOfWeek(Date.now())),
          "MM/dd"
        );
      });
    } catch (error) {}
  };

  @action submitTime = async (data: any) => {

    console.log(data);
    
  };
}

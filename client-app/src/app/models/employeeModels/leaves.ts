export interface ILeaves {
  employeeId: string;
  balance: Number;
  takenToDate: Number;
}


export interface ILeavesRequest {
  employeeId: string;
  fromDate: Date;
  toDate: Date;
  note?: string;
}

export interface ILeavesGraph {
  labels: string[],
  datasets?: IDatasets
}

interface IDatasets{
  label: string
  data?: ILeaves[]
  backgroundColor: string[]
}

export class LeavesGraph implements ILeavesGraph {
  labels: string[] = [];
  datasets: IDatasets | undefined;

  constructor(leaves?: ILeaves) {
    this.labels = ["Leaves Balance", "Taken to Date"];
    this.datasets = {
      data: [],
      label: "Leaves Data",
      backgroundColor: ["red", "green"],
    };
  }
}
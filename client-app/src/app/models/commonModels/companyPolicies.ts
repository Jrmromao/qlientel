export interface IJobTitle{
    title: string
    companyId: string
}

export interface ISchedulePolicy{
   companyId: string
   name: string
   dailyHours: string
   weekHours: string
   annualLeaves: string
}

export interface ISchedulePolicyItemList {
    value: string
    text: string
    id: string
    
    }


export interface IJobTitleItemList {
value: string
text: string
id: string

}
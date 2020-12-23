using System;

namespace Domain
{
    public class SchedulePolicy : BaseEntity
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string DailyHours { get; set; }
        public string WeekHours { get; set; }
        public string AnnualLeaves { get; set; }

    }
}
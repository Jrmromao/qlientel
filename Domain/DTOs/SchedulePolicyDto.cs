using System;

namespace Domain.DTOs
{
    public class SchedulePolicyDto
    {
        public byte[] DateCreated { get; set; }
        public CompanyDto Company { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string DailyHours { get; set; }
        public string WeekHours { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Domain
{
    public class LeaveRequest: BaseEntity
    {
        public LeaveRequest()
        {
            Employee = new List<EmployeeDetails>();
        }

        public enum LeaveStatus
        {
            Aproved = 1,
            Denied = 2,
            UnderReview = 0
        }
        public  EmployeeDetails SentTo { get; set; }
        public Guid SentToId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Guid EmployeeID { get; set; }
        public ICollection<EmployeeDetails> Employee { get; set; }
        public string Note { get; set; }
        public LeaveStatus Status { get; set; }
    }
}
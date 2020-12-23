using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class LeaveRequestDto
    {
        public LeaveRequestDto()
        {
            Employee = new List<EmployeeDetailsDto>();
        }

        public enum LeaveStatus
        {
            Aproved = 1,
            Denied = 2,
            UnderReview = 0
        }

        public EmployeeDetailsDto SentTo { get; set; }
        public Guid SentToId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Guid EmployeeID { get; set; }
        public ICollection<EmployeeDetailsDto> Employee { get; set; }
        public string Note { get; set; }
        public LeaveStatus Status { get; set; }
    }
}
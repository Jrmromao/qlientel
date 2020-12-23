using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
   public class LeavesDto
    {
        public Guid EmployeeId { get; set; }
        public EmployeeDetailsDto Employee { get; set; }
        public string Balance { get; set; }
        public string TakenToDate { get; set; }

    }
}

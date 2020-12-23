using System;
using System.Collections.Generic;

namespace Domain
{
    public class Leaves : BaseEntity
    {
    

        public Guid EmployeeId { get; set; }
        public  EmployeeDetails Employee { get; set; }
        public string Balance { get; set; }
        public string TakenToDate { get; set; }

    }
}
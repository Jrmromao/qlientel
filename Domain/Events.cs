using System;
using System.Collections.Generic;

namespace Domain
{
    public class Events : BaseEntity
    {
        public Events()
        {
            Employee = new List<EmployeeDetails>();
        }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string Description { get; set; }
        public ICollection<EmployeeDetails> Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Employees = new List<EmployeeDetails>();
        }


        public  Guid ManagerId { get; set; }
        [NotMapped]
        public AppUser Manager { get; set; }
        public Office Office { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeDetails> Employees { get; set; }
    }
}
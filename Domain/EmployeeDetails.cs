using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class EmployeeDetails : BaseEntity
    {
        public EmployeeDetails()
        {
            Documents = new List<Documents>();
        }


        [NotMapped]
        public AppUser ReportsTo { get; set; }
        public Guid ReportsId { get; set; }
  
        public string EmploymentTerm  { get; set; }
        public string JobTitle { get; set; }
        public Address Address { get; set; }
        public BankDetails BankDetails { get; set; }
        public Guid? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
        public ICollection<Documents> Documents { get; set; }
        public string PPS { get; set; }
        public DateTime SDate { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AppUser AppUser { get; set; }
        public string SchedulePolicy { get; set; }
        public string Title { get; set; }
        public Events Events { get; set; }
        public Leaves Leaves { get; set; }

    }
}
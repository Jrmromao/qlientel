using System;
using System.Text;

namespace Domain.DTOs
{


    public  class AppUserDto
    {
        public DateTime RegisterDate { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? EmployeeDetailsId { get; set; }
        public EmployeeDetailsDto? EmployeeDetails { get; set; }
        public DepartmentDto? Department { get; set; }
    }
}

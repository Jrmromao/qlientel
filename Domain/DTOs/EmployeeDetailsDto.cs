using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
  


    public class EmployeeDetailsDto
    {
        public EmployeeDetailsDto()
        {
            Documents = new List<DocumentsDto>();
        }

        public AddressDto Address { get; set; }
        public BankDetailsDto BankDetails { get; set; }
        public Guid? DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; }
        public EmergencyContactDto EmergencyContact { get; set; }
        public ICollection<DocumentsDto> Documents { get; set; }
        public string PPS { get; set; }
        public DateTime SDate { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AppUserDto AppUser { get; set; }
        public string Role { get; set; }
    }
}

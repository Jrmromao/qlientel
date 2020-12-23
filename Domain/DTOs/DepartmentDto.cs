using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class DepartmentDto
    {


        public DepartmentDto()
        {
            Employees = new List<EmployeeDetailsDto>();
        }

        public Guid Id { get; set; }
        public OfficeDto Office { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeDetailsDto> Employees { get; set; }

    }
}
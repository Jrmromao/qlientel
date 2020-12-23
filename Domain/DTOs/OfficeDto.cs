using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class OfficeDto
    {
        public CompanyDto Company { get; set; }
        public Guid CompanyId { get; set; }
        public string OfficeName { get; set; }
        public string Name { get; set; }
        public bool? IsMainHQ { get; set; }
        public string Code { get; set; }
        public ICollection<DepartmentDto>? Departments { get; set; }


    }
}
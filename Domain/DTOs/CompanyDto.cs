using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class CompanyDto
    {
        public CompanyDto()
        {
            Office = new List<OfficeDto>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<OfficeDto> Office { get; set; }
    }
}
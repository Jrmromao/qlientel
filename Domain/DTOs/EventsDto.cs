using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class EventsDto
    {
        public EventsDto()
        {
            Employee = new List<EmployeeDetailsDto>();
        }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string Description { get; set; }
        public ICollection<EmployeeDetailsDto> Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}

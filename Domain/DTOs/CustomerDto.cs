using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PointOfContact { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto Address { get; set; }
        public ICollection<DocumentsDto> Documents { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}

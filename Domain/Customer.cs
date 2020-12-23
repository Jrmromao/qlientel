using System;
using System.Collections.Generic;

namespace Domain
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Documents = new List<Documents>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PointOfContact { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public ICollection<Documents> Documents { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Office : BaseEntity
    {
        public Office()
        {
            Departments = new List<Department>();
        }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string OfficeName { get; set; }
        public bool? IsMainHQ { get; set; }
        public string Code { get; set; }
        public Address Address { get; set; }
        public ICollection<Department> Departments { get; set; }



    }
}

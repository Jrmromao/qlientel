using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Documents : BaseEntity
    {
   
        public Guid EmployeeDetailsId { get; set; }
        public string Uri { get; set; }
    }
}
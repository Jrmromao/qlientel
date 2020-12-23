using Microsoft.AspNetCore.Identity;
using System;

namespace Domain
{

    public class AppUser : IdentityUser
    {
        public DateTime RegisterDate { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? EmployeeDetailsId { get; set; }
        public EmployeeDetails? EmployeeDetails { get; set; }

    }
}
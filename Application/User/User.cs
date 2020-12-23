using System;
using System.Collections.Generic;

namespace Application.User
{
    public class User
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string EmployeeId { get; set; }
        public string Department { get; set; }
        public string company { get; set; }

        //public EmployeeDetails EmployeeDetails { get; set; }
        public string DepartmentId { get; set; }

        public ICollection<string> Role { get; set; }
        public Guid CompanyId { get; internal set; }
    }
}
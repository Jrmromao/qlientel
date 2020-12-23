using System;
using System.Collections.Generic;
using System.Text;

namespace Templates.ViewModels
{
   public class EmployeeDetailsModel
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string EmailToken { get; set; }
        public string PasswordToken { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string ManagerName { get; set; }
        public string ManageerEmail { get; set; }


    }
}

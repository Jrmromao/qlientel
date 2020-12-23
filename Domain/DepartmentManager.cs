using System;

namespace Domain
{
    public class DepartmentManager
    {
        public Guid Id { get; set; }
        public string Department { get; set; }
        public Guid DepartmentID { get; set; }
        public Guid EmployeeID { get; set; }

    }
}
using System.Collections.Generic;

namespace Domain
{

    public class Company : BaseEntity
    {
        public Company()
        {
            Office = new List<Office>();
            JobTitle = new List<JobTitle>();
            SchedulePolicy = new List<SchedulePolicy>();
            Customers = new List<Customer>();
        }

        public ICollection<SchedulePolicy> SchedulePolicy { get; set; }
        public ICollection<JobTitle> JobTitle { get; set; }
        public string Name { get; set; }
        public ICollection<Office> Office { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
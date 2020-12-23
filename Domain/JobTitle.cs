using System;


namespace Domain
{
    public class JobTitle : BaseEntity
    {
        public string Title { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }


    }

}
using System;

namespace Domain
{
    public class EmergencyContact : BaseEntity
    {

       
        public string Name { get; set; }
        public string Relation { get; set; }
        public string PhoneNumber { get; set; }
    }
}
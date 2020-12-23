namespace Domain
{


    public class Address : BaseEntity
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostCode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }

    }
}
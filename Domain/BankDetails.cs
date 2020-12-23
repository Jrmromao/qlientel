namespace Domain
{


    public class BankDetails : BaseEntity
    {
 
        public string AccountNumber { get; set; }
        public string SortCode { get; set; }
        public string BIC { get; set; }
        public string IBAN { get; set; }
    }

}
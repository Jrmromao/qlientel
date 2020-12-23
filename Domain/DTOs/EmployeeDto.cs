using System;

namespace Domain.DTOs
{
    public class EmployeeDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        //details
        public string PPS { get; set; }
        public DateTime SDate { get; set; }
        public double Salary { get; set; }
        public DateTime BirthdayDate { get; set; }
        //address
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostCode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        //bank details
        public string AccountNumber { get; set; }
        public string SortCode { get; set; }
        public string BIC { get; set; }
        public string IBAN { get; set; }
        //emergency contact
        public string EmergencyName { get; set; }
        public string EmergencyRelation { get; set; }
        public string EmergencyPhoneNumber { get; set; }


    }
}

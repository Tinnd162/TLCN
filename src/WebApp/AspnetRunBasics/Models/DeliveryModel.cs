namespace AspnetRunBasics.Models
{
    public class DeliveryModel
    {
        public string DeliveryID { get; set; }
        public string FirstNameReceiver { get; set; }
        public string LastNameReceiver { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool cus_IsExist { get; set; }
    }
}
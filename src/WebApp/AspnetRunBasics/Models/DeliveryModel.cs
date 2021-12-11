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
        public bool IsExist { get; set; }
    }
}
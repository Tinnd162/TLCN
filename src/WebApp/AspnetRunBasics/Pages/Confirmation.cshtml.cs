using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class ConfirmationModel : PageModel
    {
        public string Message { get; set; }

        public void OnGetContact()
        {
            Message = "Your email was sent.";
        }

        public void OnGetOrderSubmitted(string Id)
        {
            Message = "Đơn hàng tạo thành công, vui lòng chờ xác nhận";
        }
    }
}
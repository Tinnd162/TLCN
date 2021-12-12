using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminWebApp.Models;
using AdminWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminWebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IIdentityService _identityService;
        public LoginModel(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [BindProperty]
        public UserModel UserModel { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostLogin()
        {
            if(UserModel != null)
            {
                var objUser = await _identityService.Authenticate(UserModel);
                if(objUser.Token != null)
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddHours(1));
                    HttpContext.Response.Cookies.Append("username", objUser.UserName, cookieOptions);
                    HttpContext.Response.Cookies.Append("userid", objUser.UserID, cookieOptions);
                    HttpContext.Response.Cookies.Append("token", objUser.Token, cookieOptions);
                    return RedirectToPage("Product");
                }
                ViewData["Error"] = "Tài khoản hoặc mật khẩu không đúng!";
                return Page();
            }
            return Page();
        }
    }
}

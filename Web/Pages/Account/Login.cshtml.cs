using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private IUserService _userservice;
        public LoginModel(IUserService userservice)
        {
            _userservice = userservice;
        }
        [BindProperty]
        public LoginViewModel login { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {  
                return Page();
            }
            var user = _userservice.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    //TODO : Login User
                    return RedirectToPage("/Index",user);
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نشده است");
                }
            }
            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");

            return Page();
        }
    }
}

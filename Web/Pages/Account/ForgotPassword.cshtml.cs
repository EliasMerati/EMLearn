using Domain.Entities.User;
using Infrastructure.Convertors;
using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private IUserService _userservice;
        public ForgotPasswordModel(IUserService userservice)
        {
            _userservice = userservice;
        }
        [BindProperty]
        public ForgotPasswordViewModel forgot { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string fixemail = FixedText.FixedEmail(forgot.Email);
            User user = _userservice.GetUserByEmail(fixemail);
            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری یافت نشد");
                return Page();
            }
            return Page();
        }
    }
}

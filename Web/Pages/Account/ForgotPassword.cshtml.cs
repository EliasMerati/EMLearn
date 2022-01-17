using Domain.Entities.User;
using Infrastructure.Convertors;
using Infrastructure.DTOs;
using Infrastructure.Senders;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private IUserService _userservice;
        private IViewRenderService _renderservice;
        public ForgotPasswordModel(IUserService userservice , IViewRenderService renderservice)
        {
            _userservice = userservice;
            _renderservice = renderservice;
        }
        [BindProperty(SupportsGet = true)]
        public ForgotPasswordViewModel forgot { get; set; }
        public ViewDataAttribute IsSuccess { get; set; }
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
            string body = _renderservice.RenderToStringAsync("ForgotPass", user);
            SendEmail.Send(user.Email, "بازیابی کلمه عبور", body);
            //IsSuccess = true;
            return Page();
        }
    }
}

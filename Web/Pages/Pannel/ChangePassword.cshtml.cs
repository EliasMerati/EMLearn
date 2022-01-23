using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Pannel
{
    public class ChangePasswordModel : PageModel
    {
        private IUserService _userservice;
        public ChangePasswordModel(IUserService userservice)
        {
            _userservice = userservice;
        }
        [BindProperty(SupportsGet = true)]
        public ChangePasswordViewModel Password { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string CurrentUserName = User.Identity.Name;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!_userservice.CompareOldPassword(CurrentUserName, Password.OldPassword))
            {
                ModelState.AddModelError("OldPassword", "کلمه عبور فعلی صحیح نمیباشد");
                return Page();
            }
            _userservice.ChangeUserPassword(CurrentUserName, Password.Password);
            return Page();
        }
    }
}

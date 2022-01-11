using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;

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
                    var Claims = new List<Claim>() 
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName.ToString())
                    };
                    var Identity = new ClaimsIdentity(Claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var Principal = new ClaimsPrincipal(Identity);
                    var Properties = new AuthenticationProperties {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(Principal,Properties);
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

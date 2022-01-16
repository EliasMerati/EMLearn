using Domain.Entities.User;
using EMLearn.Infrastructure.Security;
using Infrastructure.Convertors;
using Infrastructure.DTOs;
using Infrastructure.Generators;
using Infrastructure.Senders;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Web.Pages.Account
{
    
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel user { get; set; }

        private IUserService _userservice;
        private IViewRenderService _renderservice;
        public RegisterModel(IUserService userservice, IViewRenderService renderservice)
        {
            _userservice = userservice;
            _renderservice = renderservice;
        }
        
        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_userservice.IsExistUserName(user.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نمی باشد");
                return Page();

            }
            if (_userservice.IsExistEmail(FixedText.FixedEmail(user.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل ورودی معتبر نمی باشد");
                return Page();
            }

            var newuser = new User()
            {
                UserName = user.UserName,
                Email = FixedText.FixedEmail(user.Email),
                ActiveCode = CodeGenerator.GenerateUniqCode(),
                IsActive = false,
                Password = PasswordHelper.EncodePasswordMd5(user.Password),
                RegisterDate = DateConvertor.Date(DateTime.Now),
                Avatar = "Defult.jpg",
            };
            _userservice.AddUser(newuser);

            #region Send Activation Email
            string body = _renderservice.RenderToStringAsync("ActiveMail", user);
            SendEmail.Send(newuser.Email, "فعالسازی", body);
            #endregion


            return RedirectToPage("Success", newuser);
        }
    }
}

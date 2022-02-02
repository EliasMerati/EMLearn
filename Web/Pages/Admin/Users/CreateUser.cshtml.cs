using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Web.Pages.Admin.Users
{
    public class CreateUserModel : PageModel
    {
        private IUserService _userservice;
        private IPermisionService _permisionService;
        public CreateUserModel(IUserService userservice,IPermisionService permisionService)
        {
            _userservice = userservice;
            _permisionService = permisionService;
        }
        [BindProperty]
        public CreateUserViewModel createuser { get; set; }
        public void OnGet()
        {
            ViewData["Roles"] = _permisionService.GetRoles();
        }

        public IActionResult OnPost(List<int> UserRoles)
        {
            if (!ModelState.IsValid)
                return Page();

            int userid = _userservice.AddUserByAdmin(createuser);
            //Add Roles
            _permisionService.UserRoles(userid, UserRoles);

            return Redirect("/Users");
        }
    }
}

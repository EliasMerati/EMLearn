using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Web.Pages.Admin.Users
{
    public class EditUserModel : PageModel
    {
        private IUserService _userservice;
        private IPermisionService _permisionService;
        public EditUserModel(IUserService userservice, IPermisionService permisionService)
        {
            _userservice = userservice;
            _permisionService = permisionService;
        }
        [BindProperty]
        public EditUserViewModel edituser { get; set; }
        public void OnGet(int id)
        {
            edituser = _userservice.GetUserForShowEditMode(id);
            ViewData["Roles"] = _permisionService.GetRoles();
        }

        public IActionResult OnPost(List<int> UserRoles)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userservice.EditUserByAdmin(edituser);
            // edit roles
            _permisionService.EditUserRoles(edituser.UserId, UserRoles);
            return Redirect("/Users");
        }
    }
}

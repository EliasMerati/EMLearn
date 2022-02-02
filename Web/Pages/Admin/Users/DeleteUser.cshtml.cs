using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Admin.Users
{
    public class DeleteUserModel : PageModel
    {
        private IUserService _userservice;
        public DeleteUserModel(IUserService userservice)
        {
            _userservice = userservice;
        }
        public InformationUserViewModel information { get; set; }
        public void OnGet(int id)
        {
            ViewData["id"] = id;
            information = _userservice.GetInformationUser(id);
        }

        public IActionResult OnPost(int userid)
        {
            _userservice.DeleteUser(userid);
            return Redirect("/Users");
        }
    }
}

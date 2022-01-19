using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Pannel
{
    public class EditProfileModel : PageModel
    {
        private IUserService _userservice;
        public EditProfileModel(IUserService userservice)
        {
            _userservice = userservice;
        }
        [BindProperty(SupportsGet = true)]
        public EditProfileViewModel user { get; set; }
        public void OnGet()
        {
            user = _userservice.GetDataForEditProfileUser(User.Identity.Name);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userservice.EditProfile(User.Identity.Name, _userservice.GetDataForEditProfileUser(User.Identity.Name));
            return RedirectToPage("/Logout");
        }
    }
}

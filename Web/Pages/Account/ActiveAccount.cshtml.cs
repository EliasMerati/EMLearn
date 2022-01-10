using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Account
{
    public class ActiveAccountModel : PageModel
    {
        private IUserService _userservice;
        public ActiveAccountModel(IUserService userservice)
        {
            _userservice = userservice;
        }

        

        public void OnGet()
        {
        }

        public IActionResult OnPost(string id)
        {
            if (_userservice.ActiveAccount(id))
            {

            }
            
            return Page();
        }
    }
}

using Domain.Entities.User;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Shared
{
    public class SuccessModel : PageModel
    {
        private IUserService _userservice;
        public SuccessModel(IUserService userservice)
        {
            _userservice = userservice;
        }

        public void OnGet()
        {
            
        }
    }
}

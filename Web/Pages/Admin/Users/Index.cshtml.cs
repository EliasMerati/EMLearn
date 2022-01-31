using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private IUserService _userservice;
        public IndexModel(IUserService userservice)
        {
            _userservice = userservice;
        }
        
        public UserForAdminViewModel UserForAdminViewModel { get; set; }
        public void OnGet(int Pageid = 1, string FilterUserName ="" , string FilterEmail = "")
        {
            UserForAdminViewModel = _userservice.GetUsers(Pageid,FilterEmail,FilterUserName);
        }

    }
}

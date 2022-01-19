using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Pannel
{
    [Authorize]
    [BindProperties(SupportsGet =true)]
    public class userPannelModel : PageModel
    {
        private IUserService _userservice;
        public userPannelModel(IUserService userservice)
        {
            _userservice = userservice;       
        }
        
        public InformationUserViewModel information { get; set; }


        public void OnGet()
        {
            information = _userservice.GetInformationUser(User.Identity.Name);
        }
    }
}

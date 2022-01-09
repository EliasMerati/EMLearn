using Domain.Entities.User;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Shared
{
    public class SuccessModel : PageModel
    {

        [BindProperty(SupportsGet =true)]
        public User user { get; set; }
        public void OnGet()
        {
           
            
        }
    }
}

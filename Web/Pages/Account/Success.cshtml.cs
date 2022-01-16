using Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Account
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

using Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Shared
{
    public class ForgotPassModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public void OnGet()
        {
        }
    }
}

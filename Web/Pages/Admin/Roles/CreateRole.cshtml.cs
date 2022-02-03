using Domain.Entities.User;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Admin.Roles
{
    public class CreateRoleModel : PageModel
    {
        private IPermisionService _permisionservice;
        public CreateRoleModel(IPermisionService permisionservice)
        {
            _permisionservice = permisionservice;
        }
        [BindProperty]
        public Role role { get; set; }
        public void OnGet()
        { 
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            role.IsDelete = false;
            int roleid = _permisionservice.AddRole(role);
            return Redirect("/Roles");
        }
    }
}

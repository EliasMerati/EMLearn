using Domain.Entities.User;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Admin.Roles
{
    public class EditRoleModel : PageModel
    {
        private IPermisionService _permisionservice;
        public EditRoleModel(IPermisionService permisionservice)
        {
            _permisionservice = permisionservice;
        }
        [BindProperty]
        public Role role { get; set; }
        public void OnGet(int id)
        {
            _permisionservice.GetRoleById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _permisionservice.UpdateRole(role);
            return Redirect("/Roles");
        }
    }
}

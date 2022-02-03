using Domain.Entities.User;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Admin.Roles
{
    public class DeleteRoleModel : PageModel
    {
        private IPermisionService _permisionservice;
        public DeleteRoleModel(IPermisionService permisionservice)
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
            _permisionservice.DeleteRole(role);
            return Redirect("/Roles");
        }
    }
}

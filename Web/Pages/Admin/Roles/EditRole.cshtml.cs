using Domain.Entities.User;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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
            ViewData["Permission"] = _permisionservice.GetAllPermission();
            ViewData["SellectedPermission"] = _permisionservice.PermissionsRol(id);
        }

        public IActionResult OnPost(List<int> SellectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _permisionservice.UpdateRole(role);
            _permisionservice.UpdatePermissionsRole(role.RoleId, SellectedPermission);
            return Redirect("/Roles");
        }
    }
}

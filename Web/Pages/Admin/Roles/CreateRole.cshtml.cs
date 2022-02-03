using Domain.Entities.User;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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
            ViewData["Permission"] = _permisionservice.GetAllPermission();
        }

        public IActionResult OnPost(List<int> SellectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            role.IsDelete = false;
            int roleid = _permisionservice.AddRole(role);

            _permisionservice.AddPermissionToRole(roleid,SellectedPermission);
            return Redirect("/Roles");
        }
    }
}

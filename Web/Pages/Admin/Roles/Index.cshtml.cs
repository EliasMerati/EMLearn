using Domain.Entities.User;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Web.Pages.Admin.Roles
{
    public class IndexModel : PageModel
    {
        private IPermisionService _permisionservice;
        public IndexModel(IPermisionService permisionservice)
        {
            _permisionservice = permisionservice;
        }
        public List<Role> rolelist { get; set; }
        public void OnGet()
        {
            rolelist = _permisionservice.GetRoles();
        }
    }
}

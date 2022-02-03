using Domain.Entities.Permission;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IPermisionService
    {
        #region Roles
        List<Role> GetRoles();
        int AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        Role GetRoleById(int roleid);

        void AddUserRoles(int userid, List<int> rolid);
        void EditUserRoles(int userid, List<int> rolid);
        #endregion

        #region Permissions
        List<Permission> GetAllPermission();
        void AddPermissionToRole(int roleid,List<int> permission);
        List<int> PermissionsRol(int roleid);
        void UpdatePermissionsRole(int roleid,List<int> permission);
        #endregion


    }
}

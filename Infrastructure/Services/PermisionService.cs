using Domain.Context;
using Domain.Entities.User;
using Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{

    public class PermisionService : IPermisionService
    {
        private readonly EMLearnContex _db;
        public PermisionService(EMLearnContex db)
        {
            _db = db;
        }

        public List<Role> GetRoles()
        {
            return _db.Roles.ToList();
        }

        public void AddUserRoles(int userid, List<int> rolid)
        {
            foreach (int rid in rolid)
            {
                _db.UserRoles.Add(new UsersRole()
                {
                    UserId = userid,
                    RoleId = rid
                });
                _db.SaveChanges();
            }
        }

        public void EditUserRoles(int userid, List<int> rolid)
        {
            //remove roles
            _db.UserRoles.Where(r => r.UserId == userid).ToList().ForEach(r => _db.UserRoles.Remove(r));
            // add new roles
            AddUserRoles(userid, rolid);
        }

        public int AddRole(Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
            return role.RoleId;
        }

        public Role GetRoleById(int roleid)
        {
            return _db.Roles.Find(roleid);
        }

        public void UpdateRole(Role role)
        {
            _db.Roles.Update(role);
            _db.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);
        }
    }
}

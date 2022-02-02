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

        public void UserRoles(int userid, List<int> rolid)
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
    }
}

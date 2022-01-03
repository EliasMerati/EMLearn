using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context
{
    public class EMLearnContex :DbContext
    {
        public EMLearnContex(DbContextOptions<EMLearnContex> Options) : base(Options)
        {

        }
        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersRole> UserRoles { get; set; }
        #endregion
    }
}

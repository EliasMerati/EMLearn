using Domain.Entities.User;
using Domain.Entities.Wallet;
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

        #region Wallet
        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        #endregion
    }
}

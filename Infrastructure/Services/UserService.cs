using Domain.Context;
using Domain.Entities.User;
using EMLearn.Infrastructure.Security;
using Infrastructure.Convertors;
using Infrastructure.DTOs;
using Infrastructure.Generators;
using Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly EMLearnContex _db;
        public UserService(EMLearnContex db)
        {
            _db = db;
        }

        public bool ActiveAccount(string activecode)
        {
            var user = _db.Users.SingleOrDefault(u => u.ActiveCode == activecode);
            if (user == null || user.IsActive)
            {
                return false;
            } 
            user.IsActive = true;
            user.ActiveCode = CodeGenerator.GenerateUniqCode();
            _db.SaveChanges();
            return true;
        }

        public int AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user.UserId;
        }

        public User GetUserByEmail(string email)
        {
            return _db.Users.SingleOrDefault(e => e.Email == email);
        }
         
        public bool IsExistEmail(string email)
        {
            return _db.Users.Any(u => u.Email == email);

        }

        public bool IsExistUserName(string userName)
        {
            return _db.Users.Any(_u => _u.UserName == userName);
        }

        public User LoginUser(LoginViewModel login)
        {
            string hashpass = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.FixedEmail(login.Email);
            return _db.Users.SingleOrDefault(u => u.Email == email && u.Password == hashpass);
        }
    }
}

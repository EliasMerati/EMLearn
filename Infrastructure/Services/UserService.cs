using Domain.Context;
using Domain.Entities.User;
using Domain.Entities.Wallet;
using EMLearn.Infrastructure.Security;
using Infrastructure.Convertors;
using Infrastructure.DTOs;
using Infrastructure.Generators;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

        #region User
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

        public int GetUserIdByUserName(string userName)
        {
            return _db.Users.Single(u => u.UserName == userName).UserId;
        }
        public int AddUser(User user)
        {
            _db.Entry(user).State = EntityState.Added;
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

        public void UpdateUser(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public User GetUserByUserName(string userName)
        {
            return _db.Users.SingleOrDefault(u => u.UserName == userName);
        }
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////

        #region UserPannel
        public InformationUserViewModel GetInformationUser(string username)
        {
            var user = GetUserByUserName(username);
            InformationUserViewModel information = new InformationUserViewModel();
            information.UserName = user.UserName;
            information.Email = user.Email;
            information.Wallet = BalanceUserWallet(username);
            information.RegisterDate = user.RegisterDate;

            return information;
        }

        public SideBarViewModel GetSideBarUserPannelData(string username)
        {
            return _db.Users.Where(u => u.UserName == username).Select(u => new SideBarViewModel()
            {
                UserName = u.UserName,
                ImageName = u.Avatar,
                RegisterDate = u.RegisterDate,
            }).Single();
        }

        public EditProfileViewModel GetDataForEditProfileUser(string username)
        {
            return _db.Users.Where(u => u.UserName == username).Select(u => new EditProfileViewModel()
            {
                UserName = u.UserName,
                Email = u.Email,
                AvatarName = u.Avatar
            }).Single();
        }

        public void EditProfile(string username, EditProfileViewModel profile)
        {


            if (profile.UserAvatar != null)
            {
                string ImgPath = "";
                if (profile.AvatarName != "Defult.jpg")
                {
                    ImgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
                    if (File.Exists(ImgPath))
                    {
                        File.Delete(ImgPath);
                    }
                }
                profile.AvatarName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(profile.UserAvatar.FileName);
                ImgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
                using (var stream = new FileStream(ImgPath, FileMode.Create))
                {
                    profile.UserAvatar.CopyTo(stream);
                }
            }
            var user = GetUserByUserName(username);

            user.UserName = profile.UserName;
            user.Email = profile.Email;
            user.Avatar = profile.AvatarName;

            UpdateUser(user);
        }

        public bool CompareOldPassword(string username, string oldpassword)
        {
            string HashOldPassword = PasswordHelper.EncodePasswordMd5(oldpassword);
            return _db.Users.Any(u => u.UserName == username && u.Password == HashOldPassword);
        }

        public void ChangeUserPassword(string username, string newpassword)
        {
            var user = GetUserByUserName(username);
            user.Password = PasswordHelper.EncodePasswordMd5(newpassword);
            UpdateUser(user);
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////

        #region Wallet
        public int BalanceUserWallet(string username)
        {
            var userid = GetUserIdByUserName(username);
            var deposit = _db.Wallets.Where(w => w.UserId == userid && w.TypeId == 1 && w.IsPay)
                .Select(w => w.Amount)
                .ToList();
            var withdraw = _db.Wallets.Where(w => w.UserId == userid && w.TypeId == 2)
                .Select(w => w.Amount)
                .ToList();
            return (deposit.Sum() - withdraw.Sum());
        }

        public List<WalletViewModel> GetWalletUser(string username)
        {
            int userid = GetUserIdByUserName(username);
            return _db.Wallets
                .Where(w => w.IsPay && w.UserId == userid).Select(w => new WalletViewModel
                {
                    Amount = w.Amount,
                    Date = w.CreateDate,
                    Description = w.Description,
                    Type = w.TypeId
                }).ToList();
                
        }

        public void ChargeWallet(string username, int amount,string description, bool ispay = false)
        {
            Wallet wallet = new Wallet() 
            {
                Amount = amount,
                Description = description,
                IsPay = ispay,
                TypeId = 1,
                UserId = GetUserIdByUserName(username)
            };
            AddWallet(wallet);
        }

        public void AddWallet(Wallet wallet)
        {
            _db.Wallets.Add(wallet);
            _db.SaveChanges();
        }
        #endregion
    }
}

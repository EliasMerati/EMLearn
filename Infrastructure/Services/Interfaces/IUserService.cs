using Domain.Entities.User;
using Domain.Entities.Wallet;
using Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        #region User
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        int AddUser(User user);
        void SaveUserImage(User user , EditUserViewModel editUser);
        void UpdateUser(User user);
        void DeleteUser(int userid);
        User LoginUser(LoginViewModel login);
        User GetUserById(int userid);
        User GetUserByEmail(string email);
        User GetUserByUserName(string userName);
        bool ActiveAccount(string activecode);
        int GetUserIdByUserName(string userName);
        #endregion

        #region UserPannel
        InformationUserViewModel GetInformationUser(string username);
        InformationUserViewModel GetInformationUser(int userid);
        SideBarViewModel GetSideBarUserPannelData(string username);
        EditProfileViewModel GetDataForEditProfileUser(string username);
        void EditProfile(string username, EditProfileViewModel profile);
        bool CompareOldPassword(string username, string oldpassword);
        void ChangeUserPassword(string username, string newpassword);
        #endregion

        #region Wallet
        int BalanceUserWallet(string username);
        List<WalletViewModel> GetWalletUser(string username);
        int ChargeWallet(string username ,int amount , string description,bool ispay=false);
        int AddWallet(Wallet wallet);
        Wallet GetWalletByWalletId(int walletId);
        void UpdateWallet(Wallet wallet);
        #endregion

        #region AdminPannel
        UserForAdminViewModel GetUsers(int PageId = 1 ,string FilterEmail = "" , string FilterUserName = "");
        UserForAdminViewModel GetDeleteUsers(int PageId = 1, string FilterEmail = "", string FilterUserName = "");
        int AddUserByAdmin(CreateUserViewModel user);
        EditUserViewModel GetUserForShowEditMode(int userid);
        void EditUserByAdmin(EditUserViewModel edituser);
        #endregion

    }
}

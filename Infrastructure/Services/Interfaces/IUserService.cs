using Domain.Entities.User;
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
        void UpdateUser(User user);
        User LoginUser(LoginViewModel login);
        User GetUserByEmail(string email);
        User GetUserByUserName(string userName);
        bool ActiveAccount(string activecode);
        #endregion

        #region UserPannel
        InformationUserViewModel GetInformationUser(string username);
        SideBarViewModel GetSideBarUserPannelData(string username);
        EditProfileViewModel GetDataForEditProfileUser(string username);
        void EditProfile(string username, EditProfileViewModel profile);
        #endregion

    }
}

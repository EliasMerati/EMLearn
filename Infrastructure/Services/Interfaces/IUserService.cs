using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);  
        bool IsExistEmail(string email);
        int AddUser(User user);
    }
}

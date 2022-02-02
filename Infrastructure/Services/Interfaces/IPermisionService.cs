﻿using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IPermisionService
    {
        List<Role> GetRoles();
        void AddUserRoles(int userid, List<int> rolid);
        void EditUserRoles(int userid, List<int> rolid);
    }
}
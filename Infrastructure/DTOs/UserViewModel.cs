using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs
{
    public class UserForAdminViewModel
    {
        public List<User> users { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }

    }
}

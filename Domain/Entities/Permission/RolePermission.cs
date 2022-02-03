using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Permission
{
    public class RolePermission
    {
        public RolePermission()
        {

        }

        [Key]
        public int RP_Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        #region Relations
        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
        #endregion
    }
}

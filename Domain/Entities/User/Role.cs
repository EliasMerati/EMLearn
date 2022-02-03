using Domain.Entities.Permission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
   public class Role
    {
        public Role()
        {

        }

        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [Display(Name ="نام نقش")]
        [MaxLength(200,ErrorMessage ="{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string RoleTitle { get; set; }
        public bool IsDelete { get; set; }

        #region Relations
        public virtual List<User> Users { get; set; }
        public virtual List<RolePermission> RolePermissions { get; set; }
        #endregion
    }
}

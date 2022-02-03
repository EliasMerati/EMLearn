using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Permission
{
    public class Permission
    {
        public Permission()
        {

        }

        [Key]
        public int PermissionId { get; set; }
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PermissionTitle { get; set; }
        
        public int? ParentID { get; set; }

        #region Relation
        [ForeignKey("ParentID")]
        public virtual List<Permission> Permissions { get; set; }
        public virtual List<RolePermission> RolePermissions { get; set; }
        #endregion

    }
}

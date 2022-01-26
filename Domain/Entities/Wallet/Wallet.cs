using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Wallet
{
    public class Wallet
    {

        public Wallet()
        {

        }

        [Key]
        public int WalletId { get; set; }

        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TypeId { get; set; }

        [Display(Name = "کاربر")] 
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserId { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

        [Display(Name = "انجام شده")]
        public bool IsPay { get; set; }

        [Display(Name = "شرح تراکنش")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Description { get; set; }

        [Display(Name = "تاریخ")]
        [MaxLength(11,ErrorMessage ="{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string CreateDate { get; set; }
        
        #region Relations
        public virtual User.User user { get; set; }
        public virtual WalletType WalletType { get; set; }
        #endregion

    }
}

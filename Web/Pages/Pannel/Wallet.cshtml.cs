using Infrastructure.DTOs;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Web.Pages.Pannel
{
    [Authorize]
    [BindProperties]
    public class WalletModel : PageModel
    {
        private IUserService _userservice;
        public WalletModel(IUserService userservice)
        {
            _userservice = userservice;
        }
        public ChargeWalletViewModel charge { get; set; }
        public List<WalletViewModel> list { get; set; }
        public void OnGet() => list = _userservice.GetWalletUser(User.Identity.Name);

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                list = _userservice.GetWalletUser(User.Identity.Name);
                return Page();
            }
           int walletid = _userservice.ChargeWallet(User.Identity.Name, charge.Amount, "شارژ حساب");
            #region Online Payment
            var payment = new ZarinpalSandbox.Payment(charge.Amount);
            var res = payment.PaymentRequest("شارژ حساب", "https://localhost:44307/OnlinePayment" + walletid);
            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/startpay/" + res.Result.Authority);
            }
            #endregion
            return null;
        }
    }
}

using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class OnlinePaymentModel : PageModel
    {
        private IUserService _userservice;
        public OnlinePaymentModel(IUserService userservice)
        {
            _userservice = userservice;
        }
        [BindProperty(SupportsGet = true)]
        public long refid { get; set; }
        public IActionResult OnGet(int id)
        {
            if (HttpContext.Request.Query["status"] != "" &&
                HttpContext.Request.Query["status"].ToString().ToLower() == "ok" &&
                    HttpContext.Request.Query["authority"] != "")
            {
                string authority = HttpContext.Request.Query["authority"];
                var wallet = _userservice.GetWalletByWalletId(id);
                var payment = new ZarinpalSandbox.Payment(wallet.Amount);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    refid = res.RefId;
                    wallet.IsPay = true;
                    _userservice.UpdateWallet(wallet);
                }
            }
            return Page();
        }
    }
}

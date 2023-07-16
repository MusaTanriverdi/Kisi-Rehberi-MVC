using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TelReh.Models.Context;
using TelReh.Models.Entities;
using TelReh.Models.KisiModel;

namespace TelReh.Controllers
{
    public class LoginController : Controller
    {
        MvcRehberContext db = new MvcRehberContext();


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Login(LoginVM login)
        {
            if (LoginUser(login.KullaniciAdi, login.Sifre))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.KullaniciAdi)
            };

                var userIdentity = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                 HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return RedirectToAction("Index", "Kisi");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

        private bool LoginUser(string kullaniciadi, string sifre)
        {
           var kisiler =  db.Loginler.ToList();
            if (kullaniciadi == kisiler.FirstOrDefault().KullaniciAdi && sifre == kisiler.FirstOrDefault().Sifre)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

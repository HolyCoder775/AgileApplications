using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AgileApplications.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(User user)
        {
            Context c = new Context();
            var dataValue = c.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if(dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email)
                    
                };

                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "User");
            } else
            {
                return View();
            }
        }
    }
}
//Context c = new Context();
//var dataValue = c.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
//if (dataValue != null)
//{
//    HttpContext.Session.SetString("username", user.Email);
//    return RedirectToAction("Index", "User");
//}
//else
//{
//    return View();
//}
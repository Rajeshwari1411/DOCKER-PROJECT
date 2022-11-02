using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loginpages.Models;

namespace Loginpages.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public List<UserModel> PutValue()
        {
            var users = new List<UserModel>
            {
                new UserModel{id=1,username="12345",password="RAJ"},
                new UserModel{id=2,username="13579",password="RAJ1"},
                new UserModel{id=3,username="24680",password="RAJ2"},
                new UserModel{id=4,username="98765",password="RAJ123"}
            };

            return users;
        }

        [HttpPost]
        public IActionResult Verify(UserModel usr)
        {
            var u = PutValue();

            var ue = u.Where(u => u.username.Equals(usr.username));

            var up = ue.Where(p => p.password.Equals(usr.password));

            if (up.Count() == 1)
            {
                ViewBag.message = "Login Success";
                return View("LoginSuccess");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return View("Login");
            }
        }
    }
}

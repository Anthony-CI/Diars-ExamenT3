using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnthonyCoronadoIpanaqué.DB;
using AnthonyCoronadoIpanaqué.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AnthonyCoronadoIpanaqué.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {
            var context = new AppPruebaContex();

            var user = context.Usuarios.FirstOrDefault(o => o.NombreUsuario == UserName && o.Contraseña == Password);

            if (user == null)
            {
                return View();
            }

            HttpContext.Session.Set("SessionLoggedUser", user);

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, user.NombreUsuario),

            };

            var userIdentity = new ClaimsIdentity(claims, "Login");
            var principal = new ClaimsPrincipal(userIdentity);

            HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Captura");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "AUth");
        }
    }
}
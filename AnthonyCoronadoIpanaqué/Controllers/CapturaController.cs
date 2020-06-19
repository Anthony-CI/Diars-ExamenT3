using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnthonyCoronadoIpanaqué.DB;
using AnthonyCoronadoIpanaqué.Extensions;
using AnthonyCoronadoIpanaqué.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnthonyCoronadoIpanaqué.Controllers
{
    [Authorize]
    public class CapturaController : Controller
    {

        private AppPruebaContex context = new AppPruebaContex();

        public IActionResult Index()
        {
            var userLogged = HttpContext.Session.Get<Usuario>("SessionLoggedUser");

            var model = context.Capturas
                .Include(o => o.Pokemon)
                .Where(o => o.IdUsuario == userLogged.IdUsuario);

            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult Crear()
        {

            ViewBag.Pokemones = context.Pokemones.ToList();
            return View(new Captura());
        }

        [HttpPost]
        public ActionResult Crear(Captura captura)
        {
            var userLogged = HttpContext.Session.Get<Usuario>("SessionLoggedUser");
            if (PuedoCapturarloPokeball() == true)
            {
                ModelState.AddModelError("Maximo", "se escapo");
            }

            
            if (!ModelState.IsValid)
            {
                ViewBag.Pokemones = context.Pokemones.ToList();
                return View(captura);
            }
            
            captura.IdUsuario = userLogged.IdUsuario;
            context.Capturas.Add(captura);
            ModelState.AddModelError("Maximo2", "Atrapado");
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Crearsuperball()
        {

            ViewBag.Pokemones = context.Pokemones.ToList();
            return View(new Captura());
        }

        [HttpPost]
        public ActionResult Crearsuperball(Captura captura)
        {
            var userLogged = HttpContext.Session.Get<Usuario>("SessionLoggedUser");
            if (PuedoCapturarlosuperballl() == true)
            {
                ModelState.AddModelError("Maximo", "se escapo");
            }


            if (!ModelState.IsValid)
            {
                ViewBag.Pokemones = context.Pokemones.ToList();
                return View(captura);
            }

            captura.IdUsuario = userLogged.IdUsuario;
            context.Capturas.Add(captura);
            ModelState.AddModelError("Maximo2", "Atrapado");
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Crearultraball()
        {

            ViewBag.Pokemones = context.Pokemones.ToList();
            return View(new Captura());
        }

        [HttpPost]
        public ActionResult Crearultraball(Captura captura)
        {
            var userLogged = HttpContext.Session.Get<Usuario>("SessionLoggedUser");
            if (PuedoCapturarloultraballl() == true)
            {
                ModelState.AddModelError("Maximo", "se escapo");
            }


            if (!ModelState.IsValid)
            {
                ViewBag.Pokemones = context.Pokemones.ToList();
                return View(captura);
            }

            captura.IdUsuario = userLogged.IdUsuario;
            context.Capturas.Add(captura);
            ModelState.AddModelError("Maximo2", "Atrapado");
            context.SaveChanges();
            return RedirectToAction("Index");
        }






        [HttpGet]
        public ActionResult Crearmasteball()
        {

            ViewBag.Pokemones = context.Pokemones.ToList();
            return View(new Captura());
        }

        [HttpPost]
        public ActionResult Crearmasteball(Captura captura)
        {
            var userLogged = HttpContext.Session.Get<Usuario>("SessionLoggedUser");
            if (PuedoCapturarlomasteball() == true)
            {
                ModelState.AddModelError("Maximo", "se escapo");
            }


            if (!ModelState.IsValid)
            {
                ViewBag.Pokemones = context.Pokemones.ToList();
                return View(captura);
            }

            captura.IdUsuario = userLogged.IdUsuario;
            context.Capturas.Add(captura);
            ModelState.AddModelError("Maximo2", "Atrapado");
            context.SaveChanges();
            return RedirectToAction("Index");
        }










        public bool PuedoCapturarloPokeball()
        {
            Random random = new Random();
            return random.Next(1,2)==1;
        }

        public bool PuedoCapturarlosuperballl()
        {
            Random random = new Random();
            return random.Next(1, 3) == 1;
        }

        public bool PuedoCapturarloultraballl()
        {
            Random random = new Random();
            return random.Next(1, 5) == 1;
        }


        public bool PuedoCapturarlomasteball()
        {
            Random random = new Random();
            return random.Next(1) == 1;
        }



    }
}
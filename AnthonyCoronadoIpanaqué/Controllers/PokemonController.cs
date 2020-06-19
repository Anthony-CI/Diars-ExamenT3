using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AnthonyCoronadoIpanaqué.DB;
using AnthonyCoronadoIpanaqué.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnthonyCoronadoIpanaqué.Controllers
{
    public class PokemonController : Controller
    {
        private AppPruebaContex context = new AppPruebaContex();

        private IHostingEnvironment env;

        public PokemonController(IHostingEnvironment env)
        {
            this.env = env;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult _Index(string name = "")
        {
            var query = context.Pokemones.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(o => o.Nombre.Contains(name));
            }
            
            return View(query.ToList());
        }

        [HttpGet]
        public ActionResult Crear()
        {

            return View(new Pokemon());
        }
        [HttpPost]
        public IActionResult Crear(Pokemon pokemon, IFormFile imagen)
        {
            
            if (ModelState.IsValid)
            {

                if (imagen.Length > 0)
                {
                    var filePath = Path.Combine(env.WebRootPath, "Imagenes", imagen.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imagen.CopyTo(stream);
                    }
                }
                pokemon.Imagen = imagen.FileName;
                context.Pokemones.Add(pokemon);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemon);
        }
        
    }
}
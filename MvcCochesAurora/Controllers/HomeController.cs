using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCochesAurora.Models;
using MvcCochesAurora.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCochesAurora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RepositoryCoches repo;

       
        public HomeController(ILogger<HomeController> logger, RepositoryCoches repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaCoches()
        {
            List<Coche> coches = this.repo.GetCoches();
            return View(coches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Coche coche)
        {
            this.repo.InsertCoche(coche.IdCoche, coche.Marca, coche.Modelo, coche.Conductor, coche.Imagen);
            return RedirectToAction("ListaCoches");
        }

        public IActionResult Details(int idcoche)
        {
            Coche coche = this.repo.FindCoche(idcoche);
            return View(coche);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

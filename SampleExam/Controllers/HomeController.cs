using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleExam.Models;

namespace SampleExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlanetService _planetService;

        public HomeController(IPlanetService planetService)
        {
            _planetService = planetService;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View(new PlanetsAndSpaceShip
            {
                Planets = _planetService.GetPlanetList(),
                SpaceShip = _planetService.GetSpaceShip()
            });
        }

        [HttpGet("/api/top-planets")]
        public ActionResult<TopThree> TopThree()
        {
            return _planetService.TopThree();
        }

        [HttpPost("/toship/{id}")]
        public IActionResult ToShip(long id)
        {
            _planetService.ToShip(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("/toplanet/{id}")]
        public IActionResult ToPlanet(long id)
        {
            _planetService.ToPlanet(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("/movehere/{id}")]
        public IActionResult MoveHere(long id)
        {
            _planetService.SetPlanet(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost("Add")]
        public void AddShip()
        {
            _planetService.Add(new SpaceShip
            {
                MaxCapacity = 60,
                Planet = _planetService.GetPlanetList()[0],
                Utilization = 60,
            });
        }

        [HttpPost("Remove")]
        public void Remove()
        {
            _planetService.Remove();
        }
        //[HttpPost("/movehere/{id}")]
        //public IActionResult MoveWhere(long id)
        //{

        //    return RedirectToAction(nameof(Index));
        //}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

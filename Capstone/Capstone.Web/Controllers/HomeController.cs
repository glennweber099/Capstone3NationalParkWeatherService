using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string unitSessionKey = "Unit";

        private IDetailDAO detailDAO;
        public HomeController(IDetailDAO detailDAO)
        {
            this.detailDAO = detailDAO;
        }
        public IActionResult Index()
        {
            IList<ParkModel> parks = detailDAO.GetParksIndex();
            return View(parks);
        }


        public IActionResult Detail(string parkCode)
        {
            ParkModel Park = detailDAO.GetPark(parkCode);

        //    SaveUnitPreference(Park);
            return View(Park);
        }

        [HttpPost]
        public IActionResult Detail(ParkModelVM parkModelVM)
        {
            HttpContext.Session.SetString(unitSessionKey, parkModelVM.Unit);
            return RedirectToAction("GetWeather", new { parkCode = parkModelVM.ParkCode });
        }

        public IActionResult GetWeather(string parkCode)
        {
            ViewData["unit"] = HttpContext.Session.GetString(unitSessionKey);
            IList<Weather> weathers = detailDAO.GetWeather(parkCode);
            return View(weathers);
        }

        public IActionResult GetWeatherFahrenheit(string parkCode)
        {
            IList<Weather> weathers = detailDAO.GetWeather(parkCode);
            return View(weathers);
        }

        public IActionResult GetWeatherCelsius(string parkCode)
        {
            IList<Weather> weathers = detailDAO.GetWeather(parkCode);
            return View(weathers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

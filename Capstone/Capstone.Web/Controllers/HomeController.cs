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
            HttpContext.Session.SetString("unit", parkModelVM.Unit);
            SaveUnitPreference(parkModelVM);
            return RedirectToAction("GetWeather");
        }

        private void SaveUnitPreference(ParkModelVM parkModelVM)
        {
            // Jam that baby back into session
            string unitJson = JsonConvert.SerializeObject(parkModelVM);
            HttpContext.Session.SetString(unitSessionKey, unitJson);
        }

        //private ParkModelVM GetUnitPreference()
        //{
        //    // Get the cart from session
        //    string s = HttpContext.Session.GetString(unitSessionKey);
        //    ParkModelVM park;

        //    if (s == null || s.Length == 0)
        //    {
        //        park = new ParkModelVM();
        //    }
        //    else
        //    {
        //        // Deserialize to change from a string to an object (DSO)
        //        park = JsonConvert.DeserializeObject<ParkModelVM>(s);
        //    }
        //    return park;
        //}

        public IActionResult GetWeather(string parkCode)
        {
            string s = HttpContext.Session.GetString(unitSessionKey);
            ParkModelVM park;

            if (s == null || s.Length == 0)
            {
                park = new ParkModelVM();
            }
            else
            {
                // Deserialize to change from a string to an object (DSO)
                park = JsonConvert.DeserializeObject<ParkModelVM>(s);
            }
            if (park.Unit == "Fahrenheit")
            {
                return RedirectToAction("GetWeatherFahrenheit");
            }
            else
            {
                return RedirectToAction("GetWeatherCelsius");
            }
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

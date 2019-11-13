using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAO;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
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
            //ParkModelVM vm = new ParkModelVM()
            //{
            //    park = Park
            //};
            return View(Park);
        }

        public IActionResult GetWeather(string parkCode)
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

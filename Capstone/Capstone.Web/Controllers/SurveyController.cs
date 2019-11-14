using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAO;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private IFavoriteDAO favoriteDAO;
        public SurveyController(IFavoriteDAO favoriteDAO)
        {
            this.favoriteDAO = favoriteDAO;
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(SurveyModel survey)
        {
            if (!ModelState.IsValid)
            {
                return View(survey);
            }
            // Use the DAO to add a post
            favoriteDAO.SaveNewSurvey(survey);

            // Redirect to the Confirmation page
            return RedirectToAction("Results");
        }

        [HttpGet]
        public IActionResult Results()
        {
            IList<FavoriteModel> favorites = favoriteDAO.GetFavorites();
            return View(favorites);
        }


    }
}
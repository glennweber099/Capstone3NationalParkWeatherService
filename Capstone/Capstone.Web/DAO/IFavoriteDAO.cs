using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAO
{
    public interface IFavoriteDAO
    {
        IList<FavoriteModel> GetFavorites();
        bool SaveNewSurvey(SurveyModel survey);
    }
}

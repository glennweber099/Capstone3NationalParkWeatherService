using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class _SurveyModelVM
    {
        public class SurveyModel
        {
            public int SurveyId { get; set; }
            public string ParkCode { get; set; }
            public string Email { get; set; }
            public string State { get; set; }
            public string ActivityLevel { get; set; }
            public IList<SurveyModel> Surveys { get; set; }
        }
    }
}

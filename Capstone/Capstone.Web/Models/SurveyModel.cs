using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveyId { get; }

        [Required]
        public string ParkCode { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email", Prompt = "Enter Your Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "State Name", Prompt = "Enter Your State of Residence")]
        public string State { get; set; }

        [Required]
        public string ActivityLevel { get; set; }
        public IList<SurveyModel> Surveys { get; set; }
    }
}



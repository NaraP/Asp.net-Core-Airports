using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApplication.Models
{
    public class CascadingModel
    {
        public CascadingModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AirportNames = new List<SelectListItem>();
        }
        [Display(Name = "Country")]
        public string CountryId { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }
        [Display(Name = "AirportNames")]
        public string AirportName { get; set; }
        public IList<SelectListItem> AirportNames { get; set; }

        public double DistanceBetweenTwoAirports { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCoreApplication.EuropeanAirportsRepository;
using MvcCoreApplication.EuropeCountries;
using MvcCoreApplication.Models;
using System.Device;
using System.Device.Location;

namespace MvcCoreApplication.Controllers
{
    public class EuropeanAirportsController : Controller
    {
        private IAirportsRepository AirportsRespository = null;

        public EuropeanAirportsController(IAirportsRepository _AirportsRespository)
        {
            AirportsRespository = _AirportsRespository;
        }

        // GET: EuropeanAirports
        [ExceptionLoggerFilter]
        public ActionResult Index()
        {
            CascadingModel model = new CascadingModel();
            List<SelectListItem> CounryNames = new List<SelectListItem>();

            var countries = GetCountriesList.GetEuropeCountriesList();

            foreach (var country in countries)
            {
                model.AvailableCountries.Add(new SelectListItem()
                {
                    Text = country.CountryName,
                    Value = country.CountryCode
                });
            }
            ViewBag.CountryList = model.AvailableCountries;

            return View(model);
        }


        [HttpPost]
        [ExceptionLoggerFilter]
        public ActionResult GetAirportsData(CascadingModel CountryId, IFormCollection collection)
        {
            CascadingModel model = new CascadingModel();

            string CountryCode = Request.Form["CountryId"].ToString();

           var details =  AirportsRespository.GetConvertJsonData();

            var FilterAirportsData = AirportsRespository.GetJsonFilerData(details.Result.ToList(), "", "");

            var FilterAirportNames = AirportsRespository.GetFilterAirpotNames(FilterAirportsData.ToList(), CountryCode);

            ViewBag.FilterAirportNameData = FilterAirportNames;

            foreach (var AirportNames in FilterAirportNames)
            {
                model.AirportNames.Add(new SelectListItem()
                {
                    Text = AirportNames.name
                });
            }
            ViewBag.AirportNames = model.AvailableCountries;

            return View(model);

            //return Json(cities, JsonRequestBehavior.AllowGet);
        }
        // GET: EuropeanAirports/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EuropeanAirports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EuropeanAirports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            CascadingModel model = new CascadingModel();

            var SelectedValues= Request.Form["AirportName"].ToString(); 

            //GeoCoordinate Distance = new GeoCoordinate();

            Double FLatitude1 = 0;
            Double FLatitude2 = 0;
            Double SLatitude1 = 0;
            Double SLatitude2 = 0;

            try
            {
                // TODO: Add insert logic here
                //var sCoord = new GeoCoordinate(FLatitude1, FLatitude2);

                //var eCoord = new GeoCoordinate(SLatitude1, SLatitude2);

                //var DistanceInMeters= sCoord.GetDistanceTo(eCoord);

                //model.DistanceBetweenTwoAirports = DistanceInMeters;

                return View(model);
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EuropeanAirports/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EuropeanAirports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EuropeanAirports/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EuropeanAirports/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
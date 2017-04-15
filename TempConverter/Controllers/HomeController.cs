using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TempConverter.Infrastructure;
using TempConverter.Models;

namespace TempConverter.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.conversionType = LstConversionOptions();

            var model = new TemperatureConverterViewModel();
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(string startingTemp, string conversionType)
        {
            try
            {
                int value;

                if (!int.TryParse(startingTemp, out value))
                {
                    ModelState.AddModelError("Error", "Starting Temp can only be whole numbers");
                    ViewBag.conversionType = LstConversionOptions();
                    return View("Index");
                }

                if (ModelState.IsValid)
                {
                    var data = CalculateTemperatureHelper.TempList(Convert.ToInt32(startingTemp), conversionType);

                    var model = new TemperatureConverterViewModel
                    {
                        Temp = data
                    };
                    ViewBag.conversionType = LstConversionOptions();
                    return View("Index", model);
                }

                ViewBag.conversionType = LstConversionOptions();
                return View("Index");

            }
            catch (Exception)
            {
                ViewBag.Message = "Sorry an error has occured";
                return View("Error");
            }
        }

        private static List<SelectListItem> LstConversionOptions()
        {
            List<SelectListItem> conversionOption = new List<SelectListItem>
            {
                new SelectListItem {Text = "Convert Celsius to Fahrenheit", Value = "1"},
                new SelectListItem {Text = "Convert Fahrenheit to Celsius", Value = "2"}
            };

            return conversionOption;
        }
    }
}
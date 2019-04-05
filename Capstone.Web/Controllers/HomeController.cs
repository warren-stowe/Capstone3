using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        // Dependency injections for Park and Weather DAL
        private ParkSQLDAL parkDAL;
        private WeatherSQLDAL weatherDAL;
        public HomeController(ParkSQLDAL parkDAL, WeatherSQLDAL weatherDAL)
        {
            this.parkDAL = parkDAL;
            this.weatherDAL = weatherDAL;
        }
        
        /// <summary>
        /// Shows a list of all parks with their descriptions
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            IList<ParkModel> parks = parkDAL.GetAllParks();
            return View(parks);
        }

        /// <summary>
        /// Shows a page with all the details of a specific park, weather forecast, and includes a button for choosing
        /// celsius or fahrenheit
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Detail(string parkCode)
        {
            ParkModel park = parkDAL.GetPark(parkCode);
            park.Weather = weatherDAL.GetWeather(parkCode);

            // Check to see if the HttpContext string holds a string of "C" indicating that the user wants temperature in Celsius
            // otherwise, default to Fahrenheit
            if (HttpContext.Session.GetString("Temp_Choice") == "C")
            {
                foreach (WeatherModel forecast in park.Weather)
                {
                    forecast.ConvertToCelsius();
                }
            }

            return View(park);
        }

        /// <summary>
        /// This is the detail page that is called when a post method occurs with a fahrenheit/celsius radio button selected
        /// </summary>
        /// <param name="parkCode"></param>
        /// <param name="tempChoice"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Detail(string parkCode, string tempChoice)
        {
            HttpContext.Session.SetString("Temp_Choice", tempChoice);

            ParkModel park = parkDAL.GetPark(parkCode);
            park.Weather = weatherDAL.GetWeather(parkCode);

            if (HttpContext.Session.GetString("Temp_Choice") == "C")
            {
                foreach (WeatherModel forecast in park.Weather)
                {
                    forecast.ConvertToCelsius();
                }
            }

            return View(park);
        }

        //public IActionResult Weather(string parkCode)
        //{
        //    IList<WeatherModel> forecast = weatherDAL.GetWeather(parkCode);

        //    return View(forecast);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

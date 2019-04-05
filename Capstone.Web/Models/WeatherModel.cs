using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class WeatherModel
    {
        IList<WeatherModel> Weather { get; set; }

        [Display(Name = "High temperature")]
        public double HighTemp { get; set; }

        [Display(Name = "Low temperature")]
        public double LowTemp { get; set; }

        [Display(Name = "Forecast")]
        public string Forecast { get; set; }

        [Display(Name = "Day in week value")]
        public int FiveDayForecastValue { get; set; }

        [Display(Name = "Image filename")]
        public string ImageName
        {
            get
            {
                string path = Forecast;
                if (Forecast == "partly cloudy")
                {
                    path = "partlyCloudy";
                }
                return path + ".png";

                //return Forecast.Replace(" ", string.Empty);
            }
        }

        public void ConvertToCelsius()
        {
            LowTemp = (LowTemp - 32.0) * (5 / 9.0);
            HighTemp = (HighTemp - 32.0) * (5 / 9.0);
        }

        //public string DayConverter(int day)
        //{
        //    switch (day)
        //    {
        //        case (1):
        //            return "Monday";
        //        case (2):
        //            return "Tuesday";
        //        case (3):
        //            return "Wednesday";
        //        case (4):
        //            return "Thursday";
        //        case (5):
        //            return "Friday";
        //    }
        //}
    }
}

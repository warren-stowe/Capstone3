using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkModel
    {
        [Display(Name = "Name of Park")]
        public string ParkName { get; set; }

        public string ParkCode { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string State { get; set; }

        public string Path
        {
            get
            {
                string file = "";
                file = ParkCode + ".jpg";
                return file;
            }
        }

        //public string ImagePath
        //{
        //    get
        //    {
        //        return ParkCode + ".jpg";
        //    }
        //}

        public int Acreage { get; set; }

        public int Elevation { get; set; }

        public int MilesOfTrail { get; set; }

        public int NumberOfCampsites { get; set; }

        public string Climate { get; set; }

        public int YearFounded { get; set; }

        public int AnnualVisitors { get; set; }

        public string Quote { get; set; }

        public string QuoteSource { get; set; }

        public decimal EntryFee { get; set; }

        public int NumberOfAnimalSpecies { get; set; }

        public IList<WeatherModel> Weather { get; set; } = new List<WeatherModel>();

    }

}

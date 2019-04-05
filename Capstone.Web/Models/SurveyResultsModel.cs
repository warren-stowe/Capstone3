using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResultsModel
    {

        public int ParkVotes { get; set; }

        public string ParkName { get; set; }

        public string ParkCode { get; set; }

        public string ImagePath
        {
            get
            {
                return ParkCode + ".jpg";
            }
        }

    }
}

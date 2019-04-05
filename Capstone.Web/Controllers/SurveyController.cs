using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {

        private ParkSQLDAL parkSqlDAL;
        private SurveySqlDAL surveySqlDAL;

        public SurveyController(ParkSQLDAL parkSqlDAL, SurveySqlDAL surveySqlDAL)
        {
            this.parkSqlDAL = parkSqlDAL;
            this.surveySqlDAL = surveySqlDAL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Dictionary<string, string> parks = parkSqlDAL.GetParkNames();
            
            SurveyModel surveyModel = new SurveyModel();
            surveyModel.ParksByName(parks);

            return View(surveyModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewSurvey(SurveyModel surveyModel)
        {
            if (!ModelState.IsValid)
            {
                Dictionary<string, string> parks = parkSqlDAL.GetParkNames();

                SurveyModel surveyModelReplacement = new SurveyModel();
                surveyModelReplacement.ParksByName(parks);

                return View("Index", surveyModelReplacement);
            }

            surveySqlDAL.SaveSurvey(surveyModel);

            return RedirectToAction("SurveyResults");
        }  

        public IActionResult SurveyResults()
        {
            IList<SurveyResultsModel> surveyResults = new List<SurveyResultsModel>();
            surveyResults = surveySqlDAL.GetSurveyResults();

            return View(surveyResults);
        }
    }
}
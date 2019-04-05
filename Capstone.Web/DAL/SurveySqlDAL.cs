using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL
    {
        private string connectionString;

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int SaveSurvey(SurveyModel surveyModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("insert into survey_result values (@parkCode, @emailAddress, @state, @activityLevel);", connection);
                    cmd.Parameters.AddWithValue("@parkCode", surveyModel.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", surveyModel.Email);
                    cmd.Parameters.AddWithValue("@state", surveyModel.State);
                    cmd.Parameters.AddWithValue("@activityLevel", surveyModel.ActivityLevel);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<SurveyResultsModel> GetSurveyResults()
        {
            IList<SurveyResultsModel> result = new List<SurveyResultsModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("select count(*) as TotalVotes, parkName, park.parkCode from survey_result " +
                        "join park on park.parkCode = survey_result.parkCode " +
                        "group by parkName, park.parkCode order by TotalVotes desc;", connection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyResultsModel surveyResultsModel = new SurveyResultsModel();
                        surveyResultsModel.ParkName = Convert.ToString(reader["parkName"]);
                        surveyResultsModel.ParkCode = Convert.ToString(reader["parkCode"]);
                        surveyResultsModel.ParkVotes = Convert.ToInt32(reader["TotalVotes"]);

                        result.Add(surveyResultsModel);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

    }
}

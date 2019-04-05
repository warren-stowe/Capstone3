using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class WeatherSQLDAL
    {
        private string connectionString;

        private const string SQL_GetWeather = "Select * from weather where parkCode = @parkCode;";

        public WeatherSQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<WeatherModel> GetWeather(string code)
        {
            IList<WeatherModel> weather = new List<WeatherModel>(); // hold list of weather
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetWeather, conn);

                    cmd.Parameters.AddWithValue("@parkCode", code);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WeatherModel park = new WeatherModel();

                        park.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        park.LowTemp = Convert.ToDouble(reader["low"]);
                        park.HighTemp = Convert.ToDouble(reader["high"]);
                        park.Forecast = Convert.ToString(reader["forecast"]);

                        weather.Add(park);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return weather;
        }
    }
}

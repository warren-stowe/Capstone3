using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkSQLDAL
    {
        private string connectionString;

        private const string SQL_GetPark = "Select * from park where parkCode = @parkCode;";

        public ParkSQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// Getting a list of all parks to display in view
        /// </summary>
        /// <returns></returns>
        public IList<ParkModel> GetAllParks()
        {
            IList<ParkModel> parks = new List<ParkModel>(); // hold list of parks
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * from park", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Create a park
                        ParkModel park = new ParkModel();
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Description = Convert.ToString(reader["parkDescription"]);

                        parks.Add(park);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return parks;
        }

        public Dictionary<string, string> GetParkNames()
        {
            Dictionary<string, string> parkNames = new Dictionary<string, string>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT parkName, parkCode from park", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        parkNames.Add(Convert.ToString(reader["parkCode"]), Convert.ToString(reader["parkName"]));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return parkNames;

        }

        public ParkModel GetPark(string code)
        {
            ParkModel park = new ParkModel();
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetPark, conn);
                    cmd.Parameters.AddWithValue("@parkCode", code);
               

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Description = Convert.ToString(reader["parkDescription"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.EntryFee = Convert.ToDecimal(reader["entryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return park;
        }
    }
}

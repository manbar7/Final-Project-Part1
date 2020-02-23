using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOMSSQL
{
    public class CountryDAOMSSQL : DAOs.ICountryDAO
    {

        public static SqlCommand cmd = new SqlCommand();

        public int CountryID { get; private set; }
        public string CountryName { get; private set; }

        public void Add(Country t)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"INSERT INTO COUNTRIES (COUNTRY_NAME) Values ({t.COUNTRY_NAME}) ";

            }
        }

        public Country Get(int id)
        {
            Country resultCountry = new Country();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM COUNTRIES WHERE ID = {id}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resultCountry = new Country()
                        {
                            CountryID = (int)reader["ID"],
                            CountryName = (string)reader["COUNTRY_NAME"]
                        };
                    }
                }
                return resultCountry;
            }
        }

        public IList<Country> GetAll()
        {
            IList<Country> resultCountry = new List<Country>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM COUNTRIES ";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         Country currentCountry = new Country
                         { 
                            CountryID = (int)reader["ID"],
                            CountryName = (string)reader["COUNTRY_NAME"]
                         };
                        resultCountry.Add(currentCountry);
                    }
                }
            }
            return resultCountry;
        }

        public void Remove(Country c)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"DELETE FROM COUNTRIES " +
                    $"(COUNTRY_NAME, COUNTRY_ID) " +
                    $"Values ('{c.COUNTRY_NAME}', '{c.COUNTRY_ID}')";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Country c)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"UPDATE COUNTRIES " +
                    $"SET AIRLINE_NAME = '{c.COUNTRY_NAME}', COUNTRY_CODE = '{c.COUNTRY_ID}' ";

                cmd.ExecuteNonQuery();
            }
        }
    }
}

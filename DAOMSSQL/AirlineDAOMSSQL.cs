using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOMSSQL
{
    public class AirlineDAOMSSQL : DAOs.IAirlineDAO
    {
        public static SqlCommand cmd = new SqlCommand();

        public void Add(AirlineCompany t)
        {
           using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"INSERT INTO AirlineCompanies " +
                    $"(AIRLINE_NAME, USER_NAME, PASSWORD, COUNTRY_CODE) " +
                    $"Values ('{t.AIRLINE_NAME}', '{t.USERNAME}', '{t.PASSWORD}', {t.COUNTRY_CODE})";

                cmd.ExecuteNonQuery();
            } 
        }

        public AirlineCompany Get(int id)
        {
            AirlineCompany resultAirlineCompany = new AirlineCompany();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM AirlineCompanies WHERE ID = {id}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resultAirlineCompany = new AirlineCompany()
                        {
                            AIRLINE_ID = (int)reader["ID"],
                            AIRLINE_NAME = (string)reader["AIRLINE_NAME"],
                            USERNAME = (string)reader["USER_NAME"],
                            PASSWORD = (string)reader["PASSWORD"],
                            COUNTRY_CODE = (int)reader["COUNTRY_CODE"]
                        };
                        return resultAirlineCompany;
                    }
                    return null;
                }
            }
            
        }

        public AirlineCompany GetAirlineByUserame(string Username)
        {
            AirlineCompany resultAirlineCompany = new AirlineCompany();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM AirlineCompanies WHERE USERNAME{Username}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resultAirlineCompany = new AirlineCompany()
                        {
                            AIRLINE_ID = (int)reader["ID"],
                            AIRLINE_NAME = (string)reader["AIRLINE_NAME"],
                            USERNAME = (string)reader["USER_NAME"],
                            PASSWORD = (string)reader["PASSWORD"],
                            COUNTRY_CODE = (int)reader["COUNTRY_CODE"]
                        };
                    }
                }
            }
            return resultAirlineCompany;
        }

        public IList<AirlineCompany> GetAll()
        {
            IList<AirlineCompany> resultAirlineCompany = new List<AirlineCompany>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM AirlineCompanies";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AirlineCompany CurrentresultAirlineCompany = new AirlineCompany()
                        {
                            AIRLINE_ID = (long)reader["ID"],
                            AIRLINE_NAME = (string)reader["AIRLINE_NAME"],
                            USERNAME = (string)reader["USER_NAME"],
                            PASSWORD = (string)reader["PASSWORD"],
                            COUNTRY_CODE = (long)reader["COUNTRY_CODE"]
                        };

                        resultAirlineCompany.Add(CurrentresultAirlineCompany);
                    }
                }
            }
            return resultAirlineCompany;
        }

        public IList<AirlineCompany> GetAllAirlinesByCountry(int countryId)
        {
            IList<AirlineCompany> resultAirlineCompany = new List<AirlineCompany>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM AirlineCompanies WHERE COUNTRY_CODE{countryId}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AirlineCompany CurrentresultAirlineCompany = new AirlineCompany()
                        {
                            AIRLINE_ID = (int)reader["ID"],
                            AIRLINE_NAME = (string)reader["AIRLINE_NAME"],
                            USERNAME = (string)reader["USER_NAME"],
                            PASSWORD = (string)reader["PASSWORD"],
                            COUNTRY_CODE = (int)reader["COUNTRY_CODE"]
                        };

                        resultAirlineCompany.Add(CurrentresultAirlineCompany);
                    }
                }
            }
            return resultAirlineCompany;
        }

        public void Remove(AirlineCompany t)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"DELETE FROM AirlineCompanies " +
                    $"(AIRLINE_NAME, USER_NAME, PASSWORD, COUNTRY_CODE) " +
                    $"Values ('{t.AIRLINE_NAME}', '{t.USERNAME}', '{t.PASSWORD}', {t.COUNTRY_CODE})";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(AirlineCompany t)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"UPDATE AirlineCompanies " +
                    $"SET AIRLINE_NAME = '{t.AIRLINE_NAME}', USER_NAME = '{t.USERNAME}', " +
                    $"PASSWORD = '{t.PASSWORD}', COUNTRY_CODE = '{t.COUNTRY_CODE}' " +
                    $"WHERE ID =  {t.AIRLINE_ID}";

                cmd.ExecuteNonQuery();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOMSSQL
{
    public class FlightDAOMSSQL : DAOs.IFlightDAO
    {
        public static SqlCommand cmd = new SqlCommand();

        public void Add(Flight f)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"INSERT INTO FLIGHTS " + $" (FLIGHT_ID,TICKET_ID,) " + $"Values ('{f.FLIGHT_ID}','{f.AIRLINECOMPANY_ID}','{f.ORIGIN_COUNTRY_CODE}','{f.DESTINATION_COUNTRY_CODE}','{f.DEPARTURE_TIME}','{f.LANDING_TIME}','{f.REMAINING_TICKETS}' )";
                cmd.ExecuteNonQuery();
            }
        }

        public Flight Get(int id)
        {
            Flight resultFlight = new Flight();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM FLIGHTS WHERE ID = {id}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resultFlight = new Flight()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            AIRLINECOMPANY_ID = (int)reader["AIRLINECOMPANY_ID"],
                            ORIGIN_COUNTRY_CODE = (int)reader["ORIGIN_COUNTRY_CODE"],
                            DESTINATION_COUNTRY_CODE = (int)reader["DESTINATION_COUNTRY_CODE"],
                            DEPARTURE_TIME = (DateTime)reader["DEPARTURE_TIME"],
                            LANDING_TIME = (DateTime)reader["LANDING_TIME"],
                            REMAINING_TICKETS = (int)reader["REMAINING_TICKETS"]
                           

                        };
                        return resultFlight;
                    }
                    return null;
                }
            }
            
        }

        public IList<Flight> GetAll()
        {
            IList<Flight> resultFlights = new List<Flight>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM FLIGHTS";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight CurrentresultFlight = new Flight()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            AIRLINECOMPANY_ID = (int)reader["AIRLINECOMPANY_ID"],
                            ORIGIN_COUNTRY_CODE = (int)reader["ORIGIN_COUNTRY_CODE"],
                            DESTINATION_COUNTRY_CODE = (int)reader["DESTINATION_COUNTRY_CODE"],
                            DEPARTURE_TIME = (DateTime)reader["DEPARTURE_TIME"],
                            LANDING_TIME = (DateTime)reader["LANDING_TIME"],
                            REMAINING_TICKETS = (int)reader["REMAINING_TICKETS"]
                        };

                        resultFlights.Add(CurrentresultFlight);
                    }
                }
            }
            return resultFlights;
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {

            Dictionary<Flight, int> VacancyFlights = new Dictionary<Flight, int>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM FLIGHTS ";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight CurrentresultFlight = new Flight()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            AIRLINECOMPANY_ID = (int)reader["AIRLINECOMPANY_ID"],
                            ORIGIN_COUNTRY_CODE = (int)reader["ORIGIN_COUNTRY_CODE"],
                            DESTINATION_COUNTRY_CODE = (int)reader["DESTINATION_COUNTRY_CODE"],
                            DEPARTURE_TIME = (DateTime)reader["DEPARTURE_TIME"],
                            LANDING_TIME = (DateTime)reader["LANDING_TIME"],
                            REMAINING_TICKETS = (int)reader["REMAINING_TICKETS"]
                        };
                        
                        VacancyFlights.Add(CurrentresultFlight,CurrentresultFlight.REMAINING_TICKETS);
                    }
                }
            }
            return null;
        }

        public Flight GetFlightById(int id)
        {
            IList<Flight> FlightsById = new List<Flight>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM FLIGHTS WHERE FLIGHT_ID {id}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight CurrentresultFlight = new Flight()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            AIRLINECOMPANY_ID = (int)reader["AIRLINECOMPANY_ID"],
                            ORIGIN_COUNTRY_CODE = (int)reader["ORIGIN_COUNTRY_CODE"],
                            DESTINATION_COUNTRY_CODE = (int)reader["DESTINATION_COUNTRY_CODE"],
                            DEPARTURE_TIME = (DateTime)reader["DEPARTURE_TIME"],
                            LANDING_TIME = (DateTime)reader["LANDING_TIME"],
                            REMAINING_TICKETS = (int)reader["REMAINING_TICKETS"]
                        };

                        FlightsById.Add(CurrentresultFlight);
                    }
                }
            }
            return null;
        }

        public IList<Flight> GetFlightsByCustomer(Customer customer)
        {
            IList<Flight> FlightsbyId = new List<Flight>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM FLIGHTS WHERE CUSTOMER_ID{customer.CUSTOMER_ID}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight CurrentresultFlight = new Flight()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            AIRLINECOMPANY_ID = (int)reader["AIRLINECOMPANY_ID"],
                            ORIGIN_COUNTRY_CODE = (int)reader["ORIGIN_COUNTRY_CODE"],
                            DESTINATION_COUNTRY_CODE = (int)reader["DESTINATION_COUNTRY_CODE"],
                            DEPARTURE_TIME = (DateTime)reader["DEPARTURE_TIME"],
                            LANDING_TIME = (DateTime)reader["LANDING_TIME"],
                            REMAINING_TICKETS = (int)reader["REMAINING_TICKETS"]
                        };

                        FlightsbyId.Add(CurrentresultFlight);
                    }
                }
            }
            return null;
        }

        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            IList<Flight> FlightsbyDepartureDate = new List<Flight>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM FLIGHTS WHERE DEPARTURE_TIME{departureDate}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight CurrentresultFlight = new Flight()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            AIRLINECOMPANY_ID = (int)reader["AIRLINECOMPANY_ID"],
                            ORIGIN_COUNTRY_CODE = (int)reader["ORIGIN_COUNTRY_CODE"],
                            DESTINATION_COUNTRY_CODE = (int)reader["DESTINATION_COUNTRY_CODE"],
                            DEPARTURE_TIME = (DateTime)reader["DEPARTURE_TIME"],
                            LANDING_TIME = (DateTime)reader["LANDING_TIME"],
                            REMAINING_TICKETS = (int)reader["REMAINING_TICKETS"]
                        };

                        FlightsbyDepartureDate.Add(CurrentresultFlight);
                    }
                }
            }
            return null;
        }

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            IList<Flight> FlightsByDestinationCountry = new List<Flight>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM FLIGHTS WHERE DESTINATION_COUNTRY_CODE{countryCode}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight CurrentresultFlight = new Flight()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            AIRLINECOMPANY_ID = (int)reader["AIRLINECOMPANY_ID"],
                            ORIGIN_COUNTRY_CODE = (int)reader["ORIGIN_COUNTRY_CODE"],
                            DESTINATION_COUNTRY_CODE = (int)reader["DESTINATION_COUNTRY_CODE"],
                            DEPARTURE_TIME = (DateTime)reader["DEPARTURE_TIME"],
                            LANDING_TIME = (DateTime)reader["LANDING_TIME"],
                            REMAINING_TICKETS = (int)reader["REMAINING_TICKETS"]
                        };

                        FlightsByDestinationCountry.Add(CurrentresultFlight);
                    }
                }
            }
            return null;
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            IList<Flight> FlightsByLandingDate = new List<Flight>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM FLIGHTS WHERE LANDING_TIME{landingDate}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight CurrentresultFlight = new Flight()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            AIRLINECOMPANY_ID = (int)reader["AIRLINECOMPANY_ID"],
                            ORIGIN_COUNTRY_CODE = (int)reader["ORIGIN_COUNTRY_CODE"],
                            DESTINATION_COUNTRY_CODE = (int)reader["DESTINATION_COUNTRY_CODE"],
                            DEPARTURE_TIME = (DateTime)reader["DEPARTURE_TIME"],
                            LANDING_TIME = (DateTime)reader["LANDING_TIME"],
                            REMAINING_TICKETS = (int)reader["REMAINING_TICKETS"]
                        };

                        FlightsByLandingDate.Add(CurrentresultFlight);
                    }
                }
            }
            return null;
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            IList<Flight> FlightsByOriginCountry = new List<Flight>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM FLIGHTS WHERE ORIGIN_COUNTRY_CODE{countryCode}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight CurrentresultFlight = new Flight()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            AIRLINECOMPANY_ID = (int)reader["AIRLINECOMPANY_ID"],
                            ORIGIN_COUNTRY_CODE = (int)reader["ORIGIN_COUNTRY_CODE"],
                            DESTINATION_COUNTRY_CODE = (int)reader["DESTINATION_COUNTRY_CODE"],
                            DEPARTURE_TIME = (DateTime)reader["DEPARTURE_TIME"],
                            LANDING_TIME = (DateTime)reader["LANDING_TIME"],
                            REMAINING_TICKETS = (int)reader["REMAINING_TICKETS"]
                        };

                        FlightsByOriginCountry.Add(CurrentresultFlight);
                    }
                }
            }
            return null;
        }

        public void Remove(Flight f)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"DELETE FROM FLIGHTS " + $" (FLIGHT_ID,AIRLINECOMPANY_ID,ORIGIN_COUNTRY_CODE,DESTINATION_COUNTRY_CODE,DEPARTURE_TIME,LANDING_TIME,REMAINING_TICKETS) " + $"Values ('{f.FLIGHT_ID}','{f.AIRLINECOMPANY_ID}','{f.ORIGIN_COUNTRY_CODE}','{f.DESTINATION_COUNTRY_CODE}','{f.DEPARTURE_TIME}','{f.LANDING_TIME}','{f.REMAINING_TICKETS}' )";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Flight f)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"UPDATE FROM FLIGHTS " + $" (FLIGHT_ID,AIRLINECOMPANY_ID,ORIGIN_COUNTRY_CODE,DESTINATION_COUNTRY_CODE,DEPARTURE_TIME,LANDING_TIME,REMAINING_TICKETS) " + $"Values ('{f.FLIGHT_ID}','{f.AIRLINECOMPANY_ID}','{f.ORIGIN_COUNTRY_CODE}','{f.DESTINATION_COUNTRY_CODE}','{f.DEPARTURE_TIME}','{f.LANDING_TIME}','{f.REMAINING_TICKETS}' )";

                cmd.ExecuteNonQuery();
            }
        }
    }
}

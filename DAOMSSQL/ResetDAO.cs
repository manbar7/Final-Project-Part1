using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOMSSQL
{
    class ResetDAO : IResetDAO
    {
        ResetDAO resetDAO = new ResetDAO();

        public static SqlCommand cmd = new SqlCommand();

        public IList<Flight> DeleteOverdueFlights()
        {
            
            IList<Flight> FlightHistory = new List<Flight>();
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
                        System.DateTime x1 = new System.DateTime();
                        System.DateTime x2 = CurrentresultFlight.LANDING_TIME;
                        System.TimeSpan TimePassed = x1 - x2;
                        if (TimePassed.Hours >= 3)
                        {
                           
                            FlightHistory.Add(CurrentresultFlight);
                            resultFlights.Remove(CurrentresultFlight);
                            InsertToTicketHistory(FlightHistory);
                        }
                        
                       
                    }
                }
            }
            return resultFlights;
        }

        public IList<Ticket> InsertToTicketHistory(IList<Flight> Flighthistory)
        {
            IList<Ticket> AllTickets = new TicketDAOMSSQL().GetAll();
            IList<Ticket> TicketHistory = new List<Ticket>();

            try
            {
                foreach (Flight flight in Flighthistory)
                {
                    long id =  flight.FLIGHT_ID;
                    Ticket item = AllTickets.SingleOrDefault(x => x.FLIGHT_ID == id);
                    TicketHistory.Add(item);
                }
            }
            catch (Exception)
            {

                throw new Exception("No tickets found");
            }
            return TicketHistory;
        }
    }
}

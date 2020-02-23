using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOMSSQL
{
    public class TicketDAOMSSQL : DAOs.ITicketDAO
    {
        public static SqlCommand cmd = new SqlCommand();
        public void Add(Ticket t)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"INSERT INTO TICKETS " + $" (TICKET_ID,FLIGHT_ID,CUSTOMER_ID) " + $"Values ('{t.FLIGHT_ID}','{t.TICKET_ID}','{t.CUSTOMER_ID}' )";
                cmd.ExecuteNonQuery();
                
            }
        }

        public long AddReturnsId(Ticket t)
        {
            return t.TICKET_ID;
        }

        public Ticket Get(int id)
        {
            Ticket resultTicket = new Ticket();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM TICKETS WHERE ID = {id}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resultTicket = new Ticket()
                        {
                            FLIGHT_ID = (int)reader["FLIGHT_ID"],
                            TICKET_ID = (int)reader["TICKET_ID"],
                            CUSTOMER_ID = (int)reader["CUSTOMER_ID"]
                        };
                    }
                }
            }
            return resultTicket;
        }

        public IList<Ticket> GetAll()
        {
            IList<Ticket> resultTicket = new List<Ticket>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM TICKETS";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ticket CurrentresultTicket = new Ticket()
                        {
                            FLIGHT_ID = (int)reader["ID"],
                            TICKET_ID = (int)reader["ID"],
                            CUSTOMER_ID = (int)reader["ID"]

                        };

                        resultTicket.Add(CurrentresultTicket);
                    }
                }
            }
            return resultTicket;
        }

        public void Remove(Ticket t)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"DELETE FROM TICKETS " + $" (TICKET_ID,FLIGHT_ID,CUSTOMER_ID) " + $"Values ('{t.FLIGHT_ID}','{t.TICKET_ID}','{t.CUSTOMER_ID}' )";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Ticket t)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"UPDATE FROM TICKETS " + $" (TICKET_ID,FLIGHT_ID,CUSTOMER_ID) " + $"Values ('{t.FLIGHT_ID}','{t.TICKET_ID}','{t.CUSTOMER_ID}' )";

                cmd.ExecuteNonQuery();
            }
        }
    }
}

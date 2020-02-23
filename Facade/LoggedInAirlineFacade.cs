using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Facade
{
   public class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null && token.User != null)
            {
                if (_flightDAO.Get(Convert.ToInt32(flight.FLIGHT_ID)) != null)
                {
                    _flightDAO.Remove(flight);
                }
                else
                {
                    Console.WriteLine("Flight not found");
                }
            }
        }

        public void ChangeMyPassword(LoginToken<AirlineCompany> token, string oldPassword, string newPassword)
        {
            if (token != null && token.User != null)
            {
                if (newPassword != null)
                {
                   oldPassword = newPassword;
                    Console.WriteLine("Password changed successfully!");
                }
            }
        }

        public void CreateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null && token.User != null)
            {
                if (_flightDAO.Get(Convert.ToInt32(flight.FLIGHT_ID)) == null)
                {
                    _flightDAO.Add(flight);
                    Console.WriteLine("Flight was added successfully");
                     
                }
                else
                {
                    Console.WriteLine("Flight already exist");
                }
            }
        }

        public IList<Flight> GetAllFlights(LoginToken<AirlineCompany> token)
        {
            if (token != null && token.User != null)
            {
               if (_flightDAO.GetAll() != null)
                {
                    IList<Flight> AllFlights = new List<Flight>();
                    AllFlights = _flightDAO.GetAll();
                    return AllFlights;
                }
               else
                {
                    Console.WriteLine("No Flights");
                    return null;
                }
            }
            return null;
        }

        public IList<Ticket> GetAllTickets(LoginToken<AirlineCompany> token)
        {
            
            if (token != null && token.User != null)
            {
                if (_ticketDAO.GetAll() != null)
                {
                    IList<Ticket> AllTickets = new List<Ticket>();
                    AllTickets = _ticketDAO.GetAll();
                    return AllTickets;
                }
                else
                {
                    Console.WriteLine("No Tickets");
                    return null;
                }
            }
            return null;
        }

        public void MofidyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline)
        {
            if (token != null && token.User != null)
            {
                if (_airlineDAO.Get(Convert.ToInt32(airline.AIRLINE_ID)) != null)
                {
                    _airlineDAO.Update(airline);
                }
                else
                {
                    Console.WriteLine("Airline not found");
                }

            }
        }

        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null && token.User != null)
            {
                if (_flightDAO.Get(Convert.ToInt32(flight.FLIGHT_ID)) != null)
                {
                    _flightDAO.Update(flight);
                    
                }
                else
                {
                    Console.WriteLine("Flight not found");
                }
            }
           
        }
    }
}

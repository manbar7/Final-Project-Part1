using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Facade
{
    public class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            if (token != null && token.User != null)
            {
                if (_ticketDAO.Get(Convert.ToInt32(ticket.TICKET_ID)) != null)
                {
                    _ticketDAO.Remove(ticket);
                    Console.WriteLine("Ticket Cancelled");
                }
                else
                {
                    Console.WriteLine("Ticket not found");
                }



            }
        }

        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token)
        {
            if (token != null && token.User != null)
            {
                if (_flightDAO.GetAll() != null)
                {
                    
                    IList<Flight> AllMyFlights = _flightDAO.GetFlightsByCustomer(token.User);
                }
                else
                {
                    Console.WriteLine("No flights available");
                    return null;
                }
                
            }
            return null;
        }
        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {

            if (flight.REMAINING_TICKETS > 0)
            {
                Ticket ticket = new Ticket(flight.FLIGHT_ID, token.User.CUSTOMER_ID);
                if (token != null && token.User != null)
                {

                    ticket.TICKET_ID = _ticketDAO.AddReturnsId(ticket);

                }
                else
                {
                    throw new UserAlreadyExistException($"{token.User.FIRST_NAME} {token.User.LAST_NAME} already has ticket from this flight");
                }
                return ticket;

            }
            else
            {
                throw new TicketsSoldOutException($"All the tickets of {flight} sold out");
            }

        }
     
    }
}

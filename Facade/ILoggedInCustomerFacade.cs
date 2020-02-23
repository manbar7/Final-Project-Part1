using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Facade
{
    interface ILoggedInCustomerFacade
    {
        IList<Flight> GetAllMyFlights(LoginToken<Customer> token);
        Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight);
        void CancelTicket(LoginToken<Customer> token, Ticket ticket);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Facade
{
    interface ILoggedInAirlineFacade
    {
        IList<Ticket> GetAllTickets(LoginToken<AirlineCompany> token);
        IList<Flight> GetAllFlights(LoginToken<AirlineCompany> token);
        void CancelFlight(LoginToken<AirlineCompany> token, Flight flight);
        void CreateFlight(LoginToken<AirlineCompany> token, Flight flight);
        void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight);
        void ChangeMyPassword(LoginToken<AirlineCompany> token, string oldPassword, string newPassword);
        void MofidyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline);
    }
}

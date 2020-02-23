using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Facade
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade
    {

        public IList<AirlineCompany> GetAllAirlineCompanies()
        {
            return _airlineDAO.GetAll();

        }

        public IList<Flight> GetAllFlights()
        {
            return _flightDAO.GetAll();
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            return _flightDAO.GetAllFlightsVacancy();
        }

        public Flight GetFlightById(int id)
        {
            return _flightDAO.GetFlightById(id);
        }

        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            return _flightDAO.GetFlightsByDepatrureDate(departureDate);
        }

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            return _flightDAO.GetFlightsByDestinationCountry(countryCode);
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            return _flightDAO.GetFlightsByLandingDate(landingDate);
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            return _flightDAO.GetFlightsByOriginCountry(countryCode);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOs
{
    public interface IFlightDAO : POCOs.IBasicDB<Flight>
    {
        Dictionary<Flight, int> GetAllFlightsVacancy();
        Flight GetFlightById(int id);
        IList<Flight> GetFlightsByOriginCountry(int countryCode);
        IList<Flight> GetFlightsByDestinationCountry(int countryCode);
        IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate);
        IList<Flight> GetFlightsByLandingDate(DateTime landingDate);
        IList<Flight> GetFlightsByCustomer(Customer customer);
    }
}

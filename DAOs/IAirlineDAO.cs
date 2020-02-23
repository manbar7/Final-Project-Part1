using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOs
{
    public interface IAirlineDAO : POCOs.IBasicDB<AirlineCompany>
    {
        AirlineCompany GetAirlineByUserame(string name);
        IList<AirlineCompany> GetAllAirlinesByCountry(int countryId);
    }
}

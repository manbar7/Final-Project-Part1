using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ILoginService
    {
        bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token);
        bool TryCustomerLogin(string userName, string password, out LoginToken<Customer> token);
        bool TryAirlineLogin(string userName, string password, out LoginToken<AirlineCompany> token);
    }
}

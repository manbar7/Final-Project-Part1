using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOs
{
    public interface ICustomerDAO : POCOs.IBasicDB<Customer>
    {
        Customer GetCustomerByUserame(string name);
        
    }
}

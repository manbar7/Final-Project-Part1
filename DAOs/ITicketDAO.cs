using ClassLibrary1.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOs
{
    public interface ITicketDAO : POCOs.IBasicDB<Ticket>
    {
        long AddReturnsId(Ticket t);
    }
}

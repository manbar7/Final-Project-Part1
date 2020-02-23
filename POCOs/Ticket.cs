using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Ticket : IPoco
    {
        public long TICKET_ID { get; set; }
        public long FLIGHT_ID { get; set; }
        public long CUSTOMER_ID { get; set; }

        public Ticket()
        {
        }

        public Ticket(long fLIGHT_ID)
        {
        }

        public Ticket(long fLIGHT_ID, long cUSTOMER_ID)
        {
            this.FLIGHT_ID = fLIGHT_ID;
            this.CUSTOMER_ID = cUSTOMER_ID;
        }

        public override bool Equals(object obj)
        {
            Ticket Otherticket = obj as Ticket;
            if (Otherticket == null)
                return false;
            return
                (Otherticket.TICKET_ID == this.TICKET_ID);
        }

        public override int GetHashCode()
        {
            return (int)this.TICKET_ID;
        }

        public static bool operator ==(Ticket t1,Ticket t2)
        {
            if (ReferenceEquals(t1, null) == ReferenceEquals(t2, null))
                return true;
            if (ReferenceEquals(t1, null) || ReferenceEquals(t2, null))
                return false;
            if (t1.TICKET_ID == t2.TICKET_ID)
                return true;
            else
                return false;
        }

        public static bool operator !=(Ticket t1,Ticket t2)
        {
            return !(t1 == t2);
        }

        public override string ToString()
        {
            return ($"Ticket Num: {TICKET_ID},Flight Num:{FLIGHT_ID},Customer Num:{CUSTOMER_ID}");
        }
    }
}

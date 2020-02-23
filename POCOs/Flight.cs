using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Flight : IPoco
    {
        public long FLIGHT_ID { get; set; }
        public long AIRLINECOMPANY_ID { get; set; }
        public long ORIGIN_COUNTRY_CODE { get; set; }
        public long DESTINATION_COUNTRY_CODE { get; set; }
        public DateTime DEPARTURE_TIME { get; set; }
        public DateTime LANDING_TIME { get; set; }
        public int REMAINING_TICKETS { get; set; }

        public Flight()
        {
        }

        public override bool Equals(object obj)
        {
            Flight Otherflight = obj as Flight;
            if (Otherflight == null)
                return false;
            return
                (Otherflight.FLIGHT_ID == this.FLIGHT_ID);
        }

        public override int GetHashCode()
        {
            return (int)this.FLIGHT_ID;
        }

        public static bool operator ==(Flight f1, Flight f2)
        {
            if (ReferenceEquals(f1, null) == ReferenceEquals(f2, null))
                return true;
            if (ReferenceEquals(f1, null) || ReferenceEquals(f2, null))
                return false;
            if (f1.FLIGHT_ID == f2.FLIGHT_ID)
                return true;
            else
                return false;
        }

        public static bool operator !=(Flight f1, Flight f2)
        {
            return !(f1 == f2);
        }

        public override string ToString()
        {
            return ($"Flight Num:{FLIGHT_ID},Destination Country Code:{DESTINATION_COUNTRY_CODE},Origin Country Code:{ORIGIN_COUNTRY_CODE},Departure Time:{DEPARTURE_TIME},Landing Time:{LANDING_TIME},Remaining Tickets Left:{REMAINING_TICKETS}");
        }
    }
}

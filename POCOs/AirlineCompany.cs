using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class AirlineCompany : IPoco, IUser
    {
        public long AIRLINE_ID {get; set;}
        public string AIRLINE_NAME { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public long COUNTRY_CODE { get; set; }

        public AirlineCompany()
        {
        }

        public override bool Equals(object obj)
        {
            AirlineCompany otherAirlineCompany = obj as AirlineCompany;
            if (otherAirlineCompany == null)
                return false;
            return (otherAirlineCompany.AIRLINE_ID == this.AIRLINE_ID);
        }

        public override int GetHashCode()
        {
            return (int)this.AIRLINE_ID;
        }

        public static bool operator ==(AirlineCompany a1, AirlineCompany a2)
        {
            if (ReferenceEquals(a1,null) && ReferenceEquals(a2,null))
            {
                return true;
            }
            if (ReferenceEquals(a1,null) || ReferenceEquals(a2,null))
            {
                return false;
            }
            if (a1.AIRLINE_ID == a2.AIRLINE_ID)
                return true;
            else return false;

              
        }
        public static bool operator !=(AirlineCompany a1, AirlineCompany a2)
        {
            return !(a1 == a2);
        }

        public override string ToString()
        {
            return ($"Airline Company Name: {AIRLINE_NAME},Id:{AIRLINE_ID},Country Code:{COUNTRY_CODE}");
        }
    }

}

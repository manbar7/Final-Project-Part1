using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Country : IPoco
    {
        public long COUNTRY_ID { get; set; }
        public String COUNTRY_NAME { get; set; }
        public int countryID { get;  set; }
        public string CountryName { get; set; }
        public int CountryID { get; internal set; }

        public Country()
        {
        }

        public override bool Equals(object obj)
        {
            Country Othercountry = obj as Country;
            if (Othercountry == null)
                return false;
            return
                (Othercountry.COUNTRY_ID == this.COUNTRY_ID);
        }

        public override int GetHashCode()
        {
            return (int)this.COUNTRY_ID;
        }

        public static bool operator ==(Country c1,Country c2)
        {
            if (ReferenceEquals(c1, null) == ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;
            if (c1.COUNTRY_ID == c2.COUNTRY_ID)
                return true;
            else
                return false;
        }

        public static bool operator !=(Country c1,Country c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return ($"Country Name: {COUNTRY_NAME},Id:{COUNTRY_ID}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class FlightCenterConfig
    {
        public const string ConnectionString = @"Data Source=.;Initial Catalog=FlightsData;Integrated Security=True";

        public const string ADMIN_NAME = "admin";
        public const string ADMIN_PASSWORD = "9999";

        public const int ResetDAO = 1000 * 60 * 60 * 24; // 24 hours
    }
}

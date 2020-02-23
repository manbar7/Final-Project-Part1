using ClassLibrary1.DAOMSSQL;
using ClassLibrary1.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Threading.Timer;

namespace ClassLibrary1
{ 

    public sealed class FlyingCenterSystem
    {

        private static FlyingCenterSystem _instance;
        private static object key = new object();
        private LoginService login;
        private Timer timer;
       


        
        

        private FlyingCenterSystem()
        {
            login = new LoginService();

                timer = new Timer(new TimerCallback(TimerElapsed), null, 5000, FlightCenterConfig.ResetDAO);
            


        }

        private void TimerElapsed(object state)
        {
            
            ResetDAO resetdao = new ResetDAO();
            resetdao.DeleteOverdueFlights();
        }

        public static FlyingCenterSystem GetInstance()
        {
            if (_instance == null)
            {
                lock (key)
                {
                    if (_instance == null)
                    {
                        _instance = new FlyingCenterSystem();
                    }
                }
            }
            return _instance;
        }



        public ILoginToken Login(string username, string password)
        {

            if (login.TryAdminLogin(username, password, out LoginToken<Administrator> adminToken))
            {
                return adminToken;
            }
            if (login.TryCustomerLogin(username, password, out LoginToken<Customer> customerToken))
            {
                return customerToken;
            }
            if (login.TryAirlineLogin(username, password, out LoginToken<AirlineCompany> airlineToken))
            {
                return airlineToken;
            }
            else
            {
                throw new UserNotFoundException($"user name:{username} and password:{password} doesn't match");
            }
        }

        public FacadeBase GetFacade(ILoginToken token)
        {
            if (token == null)
            {
                return new AnonymousUserFacade();
            }
            if (token.GetType() == typeof(LoginToken<Administrator>))
            {
                return new LoggedInAdministratorFacade();
            }
            if (token.GetType() == typeof(LoginToken<Customer>))
            {
                return new LoggedInCustomerFacade();
            }
            if (token.GetType() == typeof(LoginToken<AirlineCompany>))
            {
                return new LoggedInAirlineFacade();
            }
            return new AnonymousUserFacade();
        }



    }
}

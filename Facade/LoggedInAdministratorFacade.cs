using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Facade
{
    public class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade
    {
        public void CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            
            if (token != null && token.User !=null)
            {
                if (_airlineDAO.Get(Convert.ToInt32(airline.AIRLINE_ID)) == null)
                    {
                    _airlineDAO.Add(airline);
                    }
                else
                {
                    Console.WriteLine("Airline already exist");
                    
                }
            }
            
        }

        public void CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (token != null && token.User != null)
            {
                if (_customerDAO.Get(Convert.ToInt32(customer.CUSTOMER_ID)) == null)
                {
                  
                    _customerDAO.Add(customer);
                }
                else
                {
                    Console.WriteLine("Customer Already Exist");
                }
          }
        }

        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token != null && token.User != null)
            {
                if (_airlineDAO.Get(Convert.ToInt32(airline.AIRLINE_ID)) != null)
                {
                    _airlineDAO.Remove(airline);
                }
                else
                {
                    Console.WriteLine("Airline Not Found");
                }
            }
                
        }

        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (token != null && token.User != null)
            {
                if (_customerDAO.Get(Convert.ToInt32(customer.CUSTOMER_ID)) != null)
                {
                    _customerDAO.Remove(customer);
                }
                else
                {
                    Console.WriteLine("Customer Not Found");
                }
            }
        }

        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token != null && token.User != null)
            {
                if (_airlineDAO.Get(Convert.ToInt32(airline.AIRLINE_ID)) != null)
                {
                    _airlineDAO.Update(airline);
                }
                else
                {
                    Console.WriteLine("Airline Not Found");
                }
            }
        }

        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer)
        {
            if (token != null && token.User != null)
            {
                if (_customerDAO.Get(Convert.ToInt32(customer.CUSTOMER_ID)) != null)
                {
                    _customerDAO.Update(customer);
                }
                else
                {
                    Console.WriteLine("Customer Not Found");
                }
            }
        }
    }
}

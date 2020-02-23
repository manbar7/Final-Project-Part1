using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.DAOMSSQL;
using ClassLibrary1.DAOs;

namespace ClassLibrary1
{
    public class LoginService : ILoginService
    {
        private DAOs.IAirlineDAO _airlineDAO;

        private DAOs.ICustomerDAO _customerDAO;
      //  private Dictionary<Type, Func<string, string, ILoginToken>> LoginDic;

        public LoginService()
        {
            _airlineDAO = new AirlineDAOMSSQL();
            _customerDAO = new CustomerDAOMSSQL();
          //  LoginDic = new Dictionary<Type, Func<string, string, ILoginToken>>();
            //AddToDictionary();

        }

        //public bool TryLogin<T>(string userName, string password, out ILoginToken loginToken) where T : IUser
        //{
        //    loginToken = LoginDic[typeof(T)].Invoke(userName, password);
        //    if (loginToken != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token)
        {

            if (userName == Administrator.Username && password == Administrator.Password)
            {
                token = new LoginToken<Administrator>();
                token.User = new Administrator();
                return true;
            }
            else
            {
                token = null;
                return false;
            }
        }

       

        public bool TryAirlineLogin(string userName, string password, out LoginToken<AirlineCompany> token)
        {
            AirlineCompany airlineCompany = _airlineDAO.GetAirlineByUserame(userName);
            if (airlineCompany != null)
            {
                if ((userName == airlineCompany.USERNAME) && (password == airlineCompany.PASSWORD))
                {
                    token = new LoginToken<AirlineCompany>();
                    token.User = airlineCompany;
                    return true;
                }
                else
                {
                    throw new WrongPasswordException();

                }

            }
            else
            {
                token = null;
                return false;
            }

        }


        public bool TryCustomerLogin(string userName, string password, out LoginToken<Customer> token)
        {
            Customer customer = _customerDAO.GetCustomerByUserame(userName);
            if (customer != null)
            {
                //if (userName == customer.USERNAME && password == customer.PASSWORD)
                if (password == customer.PASSWORD)
                {
                    token = new LoginToken<Customer>();
                    token.User = customer;
                    return true;

                }
                else
                {
                    throw new WrongPasswordException();
                }

            }
            else
            {
                
                token = null;
                return false;
            }

        }

        //private void AddToDictionary()
        //{
        //    LoginDic.Add(typeof(Administrator),
        //        (string userName, string password) =>
        //        {
        //            if (TryAdminLogin(userName, password, out LoginToken<Administrator> token))
        //            {
        //                return token;
        //            }
        //            return null;
        //        });
        //    LoginDic.Add(typeof(Customer),
        //        (string userName, string password) =>
        //        {
        //            if (TryCustomerLogin(userName, password, out LoginToken<Customer> token))
        //            {
        //                return token;
        //            }
        //            return null;
        //        });
        //    LoginDic.Add(typeof(AirlineCompany),
        //        (string userName, string password) =>
        //        {
        //            if (TryAirlineLogin(userName, password, out LoginToken<AirlineCompany> token))
        //            {
        //                return token(typeof(LoginToken));
        //            }
        //            return null;
        //        });
        //}
    }
}

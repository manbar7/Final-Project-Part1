using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DAOMSSQL
{
    public class CustomerDAOMSSQL : DAOs.ICustomerDAO
    {
        public static SqlCommand cmd = new SqlCommand();

        public void Add(Customer c)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"INSERT INTO CUSTOMERS " + $" (CUSTOMER_ID,FIRST_NAME,LAST_NAME,USERNAME,PASSWORD,ADRESS,PHONE_NO,CREDIT_CARD_NUMBER) "+ $"Values ('{c.CUSTOMER_ID}','{c.FIRST_NAME}','{c.LAST_NAME}','{c.USERNAME}','{c.PASSWORD}','{c.ADDRESS}','{c.PHONE_NO}','{c.CREDIT_CARD_NUMBER}' )";
                cmd.ExecuteNonQuery();
            }
        }

        public Customer Get(int id)
        {
            Customer resultCustomer = new Customer();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM CUSTOMERS WHERE ID = {id}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resultCustomer = new Customer()
                        {
                            CUSTOMER_ID = (int)reader["ID"],
                            FIRST_NAME = (string)reader["FIRST_NAME"],
                            LAST_NAME = (string)reader["LAST_NAME"],
                            USERNAME = (string)reader["USER_NAME"],
                            PASSWORD = (string)reader["PASSWORD"],                   
                            ADDRESS = (string)reader["ADRESS"],
                            PHONE_NO = (string)reader["PHONE_NO"],
                            CREDIT_CARD_NUMBER = (string)reader["CREDIT_CARD_NUMBER"]

                        };
                        return resultCustomer;
                    }
                    return null;
                    
                }
                
            }
           
        }

        public IList<Customer> GetAll()
        {
            IList<Customer> resultCustomer = new List<Customer>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM CUSTOMERS";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer CurrentresultCustomer = new Customer()
                        {
                            CUSTOMER_ID = (int)reader["ID"],
                            FIRST_NAME = (string)reader["FIRST_NAME"],
                            LAST_NAME = (string)reader["LAST_NAME"],
                            USERNAME = (string)reader["USER_NAME"],
                            PASSWORD = (string)reader["PASSWORD"],
                            ADDRESS = (string)reader["ADRESS"],
                            PHONE_NO = (string)reader["PHONE_NO"],
                            CREDIT_CARD_NUMBER = (string)reader["CREDIT_CARD_NUMBER"]
                        };

                        resultCustomer.Add(CurrentresultCustomer);
                    }
                }
            }
            return resultCustomer;
        }

        public Customer GetCustomerByUserame(string name)
        {
            IList<Customer> resultCustomer = new List<Customer>();
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"SELECT * FROM CUSTOMERS WHERE USERNAME{name}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer CurrentresultCustomer = new Customer()
                        {
                            CUSTOMER_ID = (int)reader["ID"],
                            FIRST_NAME = (string)reader["FIRST_NAME"],
                            LAST_NAME = (string)reader["LAST_NAME"],
                            USERNAME = (string)reader["USER_NAME"],
                            PASSWORD = (string)reader["PASSWORD"],
                            ADDRESS = (string)reader["ADRESS"],
                            PHONE_NO = (string)reader["PHONE_NO"],
                            CREDIT_CARD_NUMBER = (string)reader["CREDIT_CARD_NUMBER"]
                        };

                        resultCustomer.Add(CurrentresultCustomer);
                    }
                }
            }
            return null;
        }

        public void Remove(Customer c)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"DELETE FROM CUSTOMERS " + $" (CUSTOMER_ID,FIRST_NAME,LAST_NAME,USERNAME,PASSWORD,ADRESS,PHONE_NO,CREDIT_CARD_NUMBER) " + $"Values ('{c.CUSTOMER_ID}','{c.FIRST_NAME}','{c.LAST_NAME}','{c.USERNAME}','{c.PASSWORD}','{c.ADDRESS}','{c.PHONE_NO}','{c.CREDIT_CARD_NUMBER}' )";

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Customer c)
        {
            using (cmd.Connection = new SqlConnection(FlightCenterConfig.ConnectionString))
            {
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"UPDATE CUSTOMERS " +
                   $" (CUSTOMER_ID,FIRST_NAME,LAST_NAME,USERNAME,PASSWORD,ADRESS,PHONE_NO,CREDIT_CARD_NUMBER) " + $"Values ('{c.CUSTOMER_ID}','{c.FIRST_NAME}','{c.LAST_NAME}','{c.USERNAME}','{c.PASSWORD}','{c.ADDRESS}','{c.PHONE_NO}','{c.CREDIT_CARD_NUMBER}' )";

                cmd.ExecuteNonQuery();
            }
        }
    }
}

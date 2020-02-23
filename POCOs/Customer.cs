using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Customer : IPoco, IUser
    {
        public long CUSTOMER_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE_NO { get; set; }
        public string CREDIT_CARD_NUMBER { get; set; }

        public Customer()
        {
        }

        public override bool Equals(object obj)
        {
            Customer Othercustomer = obj as Customer;
            if (Othercustomer == null)
                return false;
            return (Othercustomer.CUSTOMER_ID == this.CUSTOMER_ID);
        }

        public override int GetHashCode()
        {
            return (int)this.CUSTOMER_ID;
        }

        public static bool operator ==(Customer c1,Customer c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
            {
                return true;
            }
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
            {
                return false;
            }
            if (c1.CUSTOMER_ID == c2.CUSTOMER_ID)
                return true;
            else return false;


        }
        public static bool operator !=(Customer c1, Customer c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return ($"Customer Name: {FIRST_NAME} {LAST_NAME},Id:{CUSTOMER_ID},Adress:{ADDRESS},Phone Num:{PHONE_NO}");
        }
    }
}

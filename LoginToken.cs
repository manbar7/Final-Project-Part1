using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class LoginToken<T> : ILoginToken where T : IUser
    {
        public T User { get; set; }
    }
}

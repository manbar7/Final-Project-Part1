using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.POCOs
{
    public interface IBasicDB<T> where T:IPoco
    {
        void Add(T t);
        
        void Remove(T t);
        void Update(T t);
        T Get(int id);
        IList<T> GetAll();

    }
}

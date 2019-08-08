using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestedApp.Models.DAO
{
    public interface IDAO<T>
    {
        T Create(T d);
        T Retrive(int id);
        List<T> RetriveMany(int limit, int offset);
        List<T> RetriveAll();
        T Update(T d);
        T Delete(int id);
    }
}

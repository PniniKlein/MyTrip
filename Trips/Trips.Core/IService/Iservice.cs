using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.IService
{
    public interface Iservice<T>
    {
        List<T> Get();
        T GetById(int id);
        bool Add(T user);
        bool Update(int id, T user);
        bool Delete(int id);
    }
}

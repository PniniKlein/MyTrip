using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface IOrderService
    {
        List<Order> Get();
        List<Order> GetAll();
        Order GetById(int id);
        Order Add(Order order);
        Order Update(int id, Order order);
        bool Delete(int id);
    }
}

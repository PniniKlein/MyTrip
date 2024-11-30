using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepository;

namespace Trips.Data.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        readonly DataContext _dataContext;
        public OrderRepository(DataContext dataContex)
        {
            _dataContext = dataContex;
        }
        public List<Order> Get()
        {
            return _dataContext.orders;
        }
        public Order GetById(int id)
        {
            return _dataContext.orders.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Order order)
        {
            _dataContext.orders.Add(new Order(order));
            return _dataContext.SaveData<Order>(_dataContext.orders, "order.json");
        }
        public bool Update(int id, Order order)
        {
            int index = _dataContext.orders.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _dataContext.orders[index] = new Order(id, order);
                return _dataContext.SaveData<Order>(_dataContext.orders, "order.json");
            }
            return false;
        }
        public bool Delete(int id)
        {
            bool succeed = _dataContext.orders.Remove(_dataContext.orders.FirstOrDefault(x => x.Id == id));
            if (succeed)
                return _dataContext.SaveData<Order>(_dataContext.orders, "order.json");
            return false;
        }
    }
}

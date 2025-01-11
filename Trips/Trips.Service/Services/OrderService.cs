using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servises
{
    public class OrderService : IOrderService
    {
        readonly IRepositoryManager _iManager;
        public OrderService(IRepositoryManager iManager)
        {
            IRepositoryManager _iManager;
        }
        public List<Order> Get()
        {
            return _iManager.IOrderRep.Get();
        }
        public List<Order> GetAll()
        {
            return _iManager.IOrderRep.GetAll();
        }
        public Order? GetById(int id)
        {
            return _iManager.IOrderRep.GetById(id);
        }

        public Order Add(Order order)
        {
           order= _iManager.IOrderRep.Add(order);
            if (order != null)
                _iManager.Save();
            return order;
        }
        public Order Update(int id, Order order)
        {
            order = _iManager.IOrderRep.Update(id, order);
            if (order != null)
                _iManager.Save();
            return order;
        }
        public bool Delete(int id)
        {
           bool flag=_iManager.IOrderRep.Delete(id);
            if(flag)
                _iManager.Save();
            return flag;
        }
    }
}

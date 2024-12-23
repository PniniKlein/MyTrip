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
        readonly IOrderRepository _iRepository;
        public OrderService(IOrderRepository iRepository)
        {
            _iRepository = iRepository;
        }
        public List<Order> Get()
        {
            return _iRepository.Get();
        }
        public List<Order> GetAll()
        {
            return _iRepository.GetAll();
        }
        public Order? GetById(int id)
        {
            return _iRepository.GetById(id);
        }

        public Order Add(Order order)
        {
           order= _iRepository.Add(order);
            return order;
        }
        public Order Update(int id, Order order)
        {
            order = _iRepository.Update(id, order);
            return order;
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}

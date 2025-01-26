using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.DTOs;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface IOrderService
    {
        List<OrderDto> Get();
        List<Order> GetAll();
        OrderDto GetById(int id);
        OrderDto Add(OrderDto orderDto);
        OrderDto Update(int id, OrderDto orderDto);
        bool Delete(int id);
    }
}

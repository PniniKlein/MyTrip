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
        Task<List<OrderDto>> GetAsync();
        Task<List<Order>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        Task<OrderDto> AddAsync(OrderDto orderDto);
        Task<OrderDto> UpdateAsync(int id, OrderDto orderDto);
        Task<bool> DeleteAsync(int id);
    }
}

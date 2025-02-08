using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.DTOs;
using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servises
{
    public class OrderService : IOrderService
    {
        readonly IRepositoryManager _iManager;
        private readonly IMapper _mapper;
        public OrderService(IRepositoryManager iManager,IMapper mapper)
        {
            _iManager = iManager;
            _mapper = mapper;
        }
        public async Task<List<OrderDto>> GetAsync()
        {
            List<Order> orders = await _iManager.IOrderRep.GetAsync();
            List<OrderDto> ordersDtos = _mapper.Map<List<OrderDto>>(orders);
            return ordersDtos;
        }
        public async Task<List<Order>> GetAllAsync()
        {
            return await _iManager.IOrderRep.GetAllAsync();
        }
        public async Task<OrderDto>? GetByIdAsync(int id)
        {
            Order order =await _iManager.IOrderRep.GetByIdAsync(id);
            OrderDto orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public async Task<OrderDto> AddAsync(OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            order=await _iManager.IOrderRep.AddAsync(order);
            if (order != null)
               await _iManager.SaveAsync();
            orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }
        public async Task<OrderDto> UpdateAsync(int id, OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            order =await _iManager.IOrderRep.UpdateAsync(id, order);
            if (order != null)
               await _iManager.SaveAsync();
            orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
           bool flag=await _iManager.IOrderRep.DeleteAsync(id);
            if(flag)
               await _iManager.SaveAsync();
            return flag;
        }
    }
}

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
        public List<OrderDto> Get()
        {
            List<Order> orders = _iManager.IOrderRep.Get();
            List<OrderDto> ordersDtos = _mapper.Map<List<OrderDto>>(orders);
            return ordersDtos;
        }
        public List<Order> GetAll()
        {
            return _iManager.IOrderRep.GetAll();
        }
        public OrderDto? GetById(int id)
        {
            Order order = _iManager.IOrderRep.GetById(id);
            OrderDto orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public OrderDto Add(OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            order= _iManager.IOrderRep.Add(order);
            if (order != null)
                _iManager.Save();
            orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }
        public OrderDto Update(int id, OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            order = _iManager.IOrderRep.Update(id, order);
            if (order != null)
                _iManager.Save();
            orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
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

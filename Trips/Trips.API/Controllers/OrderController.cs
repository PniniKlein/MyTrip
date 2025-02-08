using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trips.API.PostModel;
using Trips.Core.DTOs;
using Trips.Core.Entities;
using Trips.Core.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trips.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IOrderService _iService;
        readonly IMapper _mapper;
        public OrderController(IOrderService iservice,IMapper mapper)
        {
            _iService = iservice;
            _mapper = mapper;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            return await _iService.GetAsync();
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return await _iService.GetAllAsync();
        }
        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            OrderDto orderDto =await _iService.GetByIdAsync(id);
            if (orderDto == null)
                return NotFound();
            return orderDto;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post([FromBody] OrderPostModel orderPostModel)
        {
            OrderDto orderDto = _mapper.Map<OrderDto>(orderPostModel);
            orderDto =await _iService.AddAsync(orderDto);
            if (orderDto == null)
                return NotFound();
            return orderDto;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDto>> Put(int id, [FromBody] OrderPostModel orderPostModel)
        {
            OrderDto orderDto = _mapper.Map<OrderDto>(orderPostModel);
            orderDto=await _iService.UpdateAsync(id, orderDto);
            if (orderDto == null)
                return NotFound();
            return orderDto;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _iService.DeleteAsync(id);
        }
    }
}

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
        public ActionResult<IEnumerable<OrderDto>> Get()
        {
            return _iService.Get();
        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            return _iService.GetAll();
        }
        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDto> Get(int id)
        {
            OrderDto orderDto = _iService.GetById(id);
            if (orderDto == null)
                return NotFound();
            return orderDto;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<OrderDto> Post([FromBody] OrderPostModel orderPostModel)
        {
            OrderDto orderDto = _mapper.Map<OrderDto>(orderPostModel);
            orderDto = _iService.Add(orderDto);
            if (orderDto == null)
                return NotFound();
            return orderDto;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<OrderDto> Put(int id, [FromBody] OrderPostModel orderPostModel)
        {
            OrderDto orderDto = _mapper.Map<OrderDto>(orderPostModel);
            orderDto= _iService.Update(id, orderDto);
            if (orderDto == null)
                return NotFound();
            return orderDto;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

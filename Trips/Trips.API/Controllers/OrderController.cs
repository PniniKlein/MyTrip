using Microsoft.AspNetCore.Mvc;
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
        public OrderController(IOrderService iservice)
        {
            _iService = iservice;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _iService.Get();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            Order order = _iService.GetById(id);
            if (order == null)
                return NotFound();
            return order;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            order= _iService.Add(order);
            if (order == null)
                return NotFound();
            return order;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            order= _iService.Update(id, order);
            if (order == null)
                return NotFound();
            return order;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

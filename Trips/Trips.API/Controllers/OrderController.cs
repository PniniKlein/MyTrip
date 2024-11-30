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
        readonly Iservice<Order> _iService;
        public OrderController(Iservice<Order> iservice)
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
        public ActionResult<bool> Post([FromBody] Order order)
        {
            return _iService.Add(order);
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Order order)
        {
            return _iService.Update(id, order);
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;
using MyTrip.Servicies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderControllers : ControllerBase
    {
        OrderServicies service = new OrderServicies();
        // GET: api/<UserControllers>
        [HttpGet]
        public List<Order> Get()
        {
            return service.Get();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Order order)
        {
            return service.Add(order);
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Order order)
        {
            return service.Update(id, order);
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return service.Delete(id);
        }
    }
}

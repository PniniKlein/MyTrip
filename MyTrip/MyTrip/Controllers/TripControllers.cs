using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;
using MyTrip.Servicies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripControllers : ControllerBase
    {
        TripServicies service = new TripServicies();
        // GET: api/<UserControllers>
        [HttpGet]
        public List<Trip> Get()
        {
            return service.Get();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Trip trip)
        {
            return service.Add(trip);
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Trip trip)
        {
            return service.Update(id, trip);
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return service.Delete(id);
        }
    }
}

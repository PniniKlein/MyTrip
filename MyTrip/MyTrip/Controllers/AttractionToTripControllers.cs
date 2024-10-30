using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;
using MyTrip.Servicies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionToTripControllers : ControllerBase
    {
        AttractionToTripServicies service = new AttractionToTripServicies();
        // GET: api/<UserControllers>
        [HttpGet]
        public List<AttractionToTrip> Get()
        {
            return service.Get();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public AttractionToTrip Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] AttractionToTrip attractionToTrip)
        {
            return service.Add(attractionToTrip);
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] AttractionToTrip attractionToTrip)
        {
            return service.Update(attractionToTrip);
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return service.Delete(id);
        }
    }
}

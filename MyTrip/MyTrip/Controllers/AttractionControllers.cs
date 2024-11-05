using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;
using MyTrip.Servicies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionControllers : ControllerBase
    {
        AttractionServicies service = new AttractionServicies();
        // GET: api/<UserControllers>
        [HttpGet]
        public List<Attraction> Get()
        {
            return service.Get();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public ActionResult<Attraction> Get(int id)
        {
            Attraction attraction = service.GetById(id);
            if (attraction == null)
                return NotFound();
            return attraction;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Attraction attraction)
        {
            return service.Add(attraction);
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Attraction attraction)
        {
            return service.Update(id,attraction);
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return service.Delete(id);
        }
    }
}

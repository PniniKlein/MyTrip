using Microsoft.AspNetCore.Mvc;
using Trips.Core.Entities;
using Trips.Core.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trips.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        readonly ITripService _iService;
        public TripController(ITripService iservice)
        {
            _iService = iservice;
        }
        // GET: api/<TripController>
        [HttpGet]
        public ActionResult<IEnumerable<Trip>> Get()
        {
            return _iService.Get();
        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Trip>> GetAll()
        {
            return _iService.GetAll();
        }
        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public ActionResult<Trip> Get(int id)
        {
            Trip trip = _iService.GetById(id);
            if (trip == null)
                return NotFound();
            return trip;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<Trip> Post([FromBody] Trip trip)
        {
            trip= _iService.Add(trip);
            if (trip == null)
                return NotFound();
            return trip;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<Trip> Put(int id, [FromBody] Trip trip)
        {
            trip= _iService.Update(id, trip);
            if (trip == null)
                return NotFound();
            return trip;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

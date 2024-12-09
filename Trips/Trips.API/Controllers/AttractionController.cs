using Microsoft.AspNetCore.Mvc;
using Trips.Core.Entities;
using Trips.Core.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trips.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        readonly IAttractionService _iService;
        public AttractionController(IAttractionService iservice)
        {
            _iService = iservice;
        }
        // GET: api/<AttractionController>
        [HttpGet]
        public ActionResult<IEnumerable<Attraction>> Get()
        {
            return _iService.Get();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public ActionResult<Attraction> Get(int id)
        {
            Attraction attraction = _iService.GetById(id);
            if (attraction == null)
                return NotFound();
            return attraction;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<Attraction> Post([FromBody] Attraction attraction)
        {
            return _iService.Add(attraction);
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<Attraction> Put(int id, [FromBody] Attraction attraction)
        {
            return _iService.Update(id, attraction);
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

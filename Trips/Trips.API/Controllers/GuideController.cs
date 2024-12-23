using Microsoft.AspNetCore.Mvc;
using Trips.Core.Entities;
using Trips.Core.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trips.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        readonly IGuideService _iService;
        public GuideController(IGuideService iservice)
        {
            _iService = iservice;
        }
        // GET: api/<GuideController>
        [HttpGet]
        public ActionResult<IEnumerable<Guide>> Get()
        {
            return _iService.Get();
        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Guide>> GetAll()
        {
            return _iService.GetAll();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public ActionResult<Guide> Get(int id)
        {
            Guide guide = _iService.GetById(id);
            if (guide == null)
                return NotFound();
            return guide;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<Guide> Post([FromBody] Guide guide)
        {
            guide= _iService.Add(guide);
            if (guide == null)
                return NotFound();
            return guide;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<Guide> Put(int id, [FromBody] Guide guide)
        {
            guide= _iService.Update(id, guide);
            if (guide == null)
                return NotFound();
            return guide;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

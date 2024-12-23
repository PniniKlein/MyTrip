using Microsoft.AspNetCore.Mvc;
using Trips.Core.Entities;
using Trips.Core.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trips.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _iService;
        public UserController(IUserService iservice)
        {
            _iService = iservice;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _iService.Get();
        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return _iService.GetAll();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _iService.GetById(id);
            if (user == null)
                return NotFound();
            return user;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            user= _iService.Add(user);
            if (user == null)
                return NotFound();
            return user;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            user= _iService.Update(id, user);
            if (user == null)
                return NotFound();
            return user;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;
using MyTrip.Servicies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly UserServicies _userServicies;
        public UserControllers(UserServicies userServicies)
        {
            _userServicies = userServicies;
        }
        // GET: api/<UserControllers>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userServicies.Get();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _userServicies.GetById(id);
            if (user == null)
                return NotFound();
            return user;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] User user)
        {
            return _userServicies.Add(user);
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] User user)
        {
            return _userServicies.Update(id, user);
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _userServicies.Delete(id);
        }
    }
}

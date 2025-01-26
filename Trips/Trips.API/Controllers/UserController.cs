using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trips.API.PostModel;
using Trips.Core.DTOs;
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
        readonly IMapper _mapper;
        public UserController(IUserService iservice,IMapper mapper)
        {
            _iService = iservice;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
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
        public ActionResult<UserDto> Get(int id)
        {
            UserDto userDto = _iService.GetById(id);
            if (userDto == null)
                return NotFound();
            return userDto;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<UserDto> Post([FromBody] UserPostModel userPostModel)
        {
            UserDto userDto = _mapper.Map<UserDto>(userPostModel);
            userDto = _iService.Add(userDto);
            if (userDto == null)
                return NotFound();
            return userDto;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<UserDto> Put(int id, [FromBody] UserPostModel userPostModel)
        {
            UserDto userDto = _mapper.Map<UserDto>(userPostModel);
            userDto = _iService.Update(id, userDto);
            if (userDto == null)
                return NotFound();
            return userDto;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

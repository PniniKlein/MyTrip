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
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            return await _iService.GetAsync();
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _iService.GetAllAsync();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            UserDto userDto =await _iService.GetByIdAsync(id);
            if (userDto == null)
                return NotFound();
            return userDto;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserPostModel userPostModel)
        {
            UserDto userDto = _mapper.Map<UserDto>(userPostModel);
            userDto =await _iService.AddAsync(userDto);
            if (userDto == null)
                return NotFound();
            return userDto;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Put(int id, [FromBody] UserPostModel userPostModel)
        {
            UserDto userDto = _mapper.Map<UserDto>(userPostModel);
            userDto =await _iService.UpdateAsync(id, userDto);
            if (userDto == null)
                return NotFound();
            return userDto;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _iService.DeleteAsync(id);
        }
    }
}

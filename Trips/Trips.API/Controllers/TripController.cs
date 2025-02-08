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
    public class TripController : ControllerBase
    {
        readonly ITripService _iService;
        readonly IMapper _mapper;
        public TripController(ITripService iservice,IMapper mapper)
        {
            _iService = iservice;
            _mapper = mapper;
        }
        // GET: api/<TripController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDto>>> Get()
        {
            return await _iService.GetAsync();
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Trip>>> GetAll()
        {
            return await _iService.GetAllAsync();
        }
        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripDto>> Get(int id)
        {
            TripDto tripDto =await _iService.GetByIdAsync(id);
            if (tripDto == null)
                return NotFound();
            return tripDto;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public async Task<ActionResult<TripDto>> Post([FromBody] TripPostModel tripPostModel)
        {
            TripDto tripDto = _mapper.Map<TripDto>(tripPostModel);
            tripDto =await _iService.AddAsync(tripDto);
            if (tripDto == null)
                return NotFound();
            return tripDto;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TripDto>> Put(int id, [FromBody] TripPostModel tripPostModel)
        {
            TripDto tripDto = _mapper.Map<TripDto>(tripPostModel);
            tripDto =await _iService.UpdateAsync(id, tripDto);
            if (tripDto == null)
                return NotFound();
            return tripDto;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _iService.DeleteAsync(id);
        }
    }
}

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
        public ActionResult<IEnumerable<TripDto>> Get()
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
        public ActionResult<TripDto> Get(int id)
        {
            TripDto tripDto = _iService.GetById(id);
            if (tripDto == null)
                return NotFound();
            return tripDto;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<TripDto> Post([FromBody] TripPostModel tripPostModel)
        {
            TripDto tripDto = _mapper.Map<TripDto>(tripPostModel);
            tripDto = _iService.Add(tripDto);
            if (tripDto == null)
                return NotFound();
            return tripDto;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<TripDto> Put(int id, [FromBody] TripPostModel tripPostModel)
        {
            TripDto tripDto = _mapper.Map<TripDto>(tripPostModel);
            tripDto = _iService.Update(id, tripDto);
            if (tripDto == null)
                return NotFound();
            return tripDto;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

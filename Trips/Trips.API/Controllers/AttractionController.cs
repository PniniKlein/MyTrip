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
    public class AttractionController : ControllerBase
    {
        readonly IAttractionService _iService;
        readonly IMapper _mapper;
        public AttractionController(IAttractionService iservice,IMapper mapper)
        {
            _iService = iservice;
            _mapper = mapper;
        }
        // GET: api/<AttractionController>
        [HttpGet]
        public ActionResult<IEnumerable<AttractionDto>> Get()
        {
            return _iService.Get();
        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Attraction>> GetAll()
        {
            return _iService.GetAll();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public ActionResult<AttractionDto> Get(int id)
        {
            AttractionDto attractionDto = _iService.GetById(id);
            if (attractionDto == null)
                return NotFound();
            return attractionDto;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<AttractionDto> Post([FromBody] AttractionPostModel attractionPostModel)
        {
            AttractionDto attractionDto = _mapper.Map<AttractionDto>(attractionPostModel);
            attractionDto = _iService.Add(attractionDto);
            if (attractionDto == null)
                return NotFound();
            return attractionDto;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<AttractionDto> Put(int id, [FromBody] AttractionPostModel attractionPostModel)
        {
            AttractionDto attractionDto = _mapper.Map<AttractionDto>(attractionPostModel);
            attractionDto = _iService.Update(id, attractionDto);
            if (attractionDto == null)
                return NotFound();
            return attractionDto;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

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
        public async Task<ActionResult<IEnumerable<AttractionDto>>> Get()
        {
            return await _iService.GetAsync();
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Attraction>>> GetAll()
        {
            return await _iService.GetAllAsync();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttractionDto>> Get(int id)
        {
            AttractionDto attractionDto = await _iService.GetByIdAsync(id);
            if (attractionDto == null)
                return NotFound();
            return attractionDto;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public async Task<ActionResult<AttractionDto>> Post([FromBody] AttractionPostModel attractionPostModel)
        {
            AttractionDto attractionDto = _mapper.Map<AttractionDto>(attractionPostModel);
            attractionDto =await _iService.AddAsync(attractionDto);
            if (attractionDto == null)
                return NotFound();
            return attractionDto;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AttractionDto>> Put(int id, [FromBody] AttractionPostModel attractionPostModel)
        {
            AttractionDto attractionDto = _mapper.Map<AttractionDto>(attractionPostModel);
            attractionDto =await _iService.UpdateAsync(id, attractionDto);
            if (attractionDto == null)
                return NotFound();
            return attractionDto;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            return await _iService.DeleteAsync(id);
        }
    }
}

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
    public class GuideController : ControllerBase
    {
        readonly IGuideService _iService;
        readonly IMapper _mapper;
        public GuideController(IGuideService iservice,IMapper mapper)
        {
            _iService = iservice;
            _mapper = mapper;
        }
        // GET: api/<GuideController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuideDto>>> Get()
        {
            return await _iService.GetAsync();
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Guide>>> GetAll()
        {
            return await _iService.GetAllAsync();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuideDto>> Get(int id)
        {
            GuideDto guideDto =await _iService.GetByIdAsync(id);
            if (guideDto == null)
                return NotFound();
            return guideDto;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public async Task<ActionResult<GuideDto>> Post([FromBody] GuidePostModel guidePostModel)
        {
            GuideDto guideDto = _mapper.Map<GuideDto>(guidePostModel);
            guideDto=await _iService.AddAsync(guideDto);
            if (guideDto == null)
                return NotFound();
            return guideDto;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GuideDto>> PutAsync(int id, [FromBody] GuidePostModel guidePostModel)
        {
            GuideDto guideDto = _mapper.Map<GuideDto>(guidePostModel);
            guideDto =await _iService.UpdateAsync(id, guideDto);
            if (guideDto == null)
                return NotFound();
            return guideDto;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            return await _iService.DeleteAsync(id);
        }
    }
}

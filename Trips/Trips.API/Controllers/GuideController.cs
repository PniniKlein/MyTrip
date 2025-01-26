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
        public ActionResult<IEnumerable<GuideDto>> Get()
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
        public ActionResult<GuideDto> Get(int id)
        {
            GuideDto guideDto = _iService.GetById(id);
            if (guideDto == null)
                return NotFound();
            return guideDto;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<GuideDto> Post([FromBody] GuidePostModel guidePostModel)
        {
            GuideDto guideDto = _mapper.Map<GuideDto>(guidePostModel);
            guideDto= _iService.Add(guideDto);
            if (guideDto == null)
                return NotFound();
            return guideDto;
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<GuideDto> Put(int id, [FromBody] GuidePostModel guidePostModel)
        {
            GuideDto guideDto = _mapper.Map<GuideDto>(guidePostModel);
            guideDto = _iService.Update(id, guideDto);
            if (guideDto == null)
                return NotFound();
            return guideDto;
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}

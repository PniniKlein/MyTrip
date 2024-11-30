﻿using Microsoft.AspNetCore.Mvc;
using Trips.Core.Entities;
using Trips.Core.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trips.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionToTripController : ControllerBase
    {
        readonly Iservice<AttractionToTrip> _iService;
        public AttractionToTripController(Iservice<AttractionToTrip> iservice)
        {
            _iService = iservice;
        }
        // GET: api/<AttractionToTripController>
        [HttpGet]
        public ActionResult<IEnumerable<AttractionToTrip>> Get()
        {
            return _iService.Get();
        }

        // GET api/<UserControllers>/5
        [HttpGet("{id}")]
        public ActionResult<AttractionToTrip> Get(int id)
        {
            AttractionToTrip attractionToTrip = _iService.GetById(id);
            if (attractionToTrip == null)
                return NotFound();
            return attractionToTrip;
        }

        // POST api/<UserControllers>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] AttractionToTrip attractionToTrip)
        {
            return _iService.Add(attractionToTrip);
        }

        // PUT api/<UserControllers>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] AttractionToTrip attractionToTrip)
        {
            return _iService.Update(id, attractionToTrip);
        }

        // DELETE api/<UserControllers>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}
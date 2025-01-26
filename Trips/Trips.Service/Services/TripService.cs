using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.DTOs;
using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servises
{
    public class TripService : ITripService
    {
        private readonly IRepositoryManager _iManager;
        private readonly IMapper _mapper;
        public TripService(IRepositoryManager iManager,IMapper mapper)
        {
            _iManager = iManager;
            _mapper = mapper;
        }
        public List<TripDto> Get()
        {
            List<Trip> trips = _iManager.ITripRep.Get();
            List<TripDto> tripDtos = _mapper.Map<List<TripDto>>(trips);
            return tripDtos;
        }
        public List<Trip> GetAll()
        {
            return _iManager.ITripRep.GetAll();
        }
        public TripDto? GetById(int id)
        {
            Trip trip = _iManager.ITripRep.GetById(id);
            TripDto tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }

        public TripDto Add(TripDto tripDto)
        {
            Trip trip = _mapper.Map<Trip>(tripDto);
            trip= _iManager.ITripRep.Add(trip);
            if (trip != null)
                _iManager.Save();
            tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }
        public TripDto Update(int id, TripDto tripDto)
        {
            Trip trip = _mapper.Map<Trip>(tripDto);
            trip = _iManager.ITripRep.Update(id, trip);
            if (trip != null)
                _iManager.Save();
            tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }
        public bool Delete(int id)
        {
            bool flag = _iManager.ITripRep.Delete(id);
            if(flag)
                _iManager.Save();
            return flag;
        }
    }
}

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
        public async Task<List<TripDto>> GetAsync()
        {
            List<Trip> trips = await _iManager.ITripRep.GetAsync();
            List<TripDto> tripDtos = _mapper.Map<List<TripDto>>(trips);
            return tripDtos;
        }
        public async Task<List<Trip>> GetAllAsync()
        {
            return await _iManager.ITripRep.GetAllAsync();
        }
        public async Task<TripDto>? GetByIdAsync(int id)
        {
            Trip trip =await _iManager.ITripRep.GetByIdAsync(id);
            TripDto tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }

        public async Task<TripDto> AddAsync(TripDto tripDto)
        {
            Trip trip = _mapper.Map<Trip>(tripDto);
            trip=await _iManager.ITripRep.AddAsync(trip);
            if (trip != null)
               await _iManager.SaveAsync();
            tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }
        public async Task<TripDto> UpdateAsync(int id, TripDto tripDto)
        {
            Trip trip = _mapper.Map<Trip>(tripDto);
            trip =await _iManager.ITripRep.UpdateAsync(id, trip);
            if (trip != null)
               await _iManager.SaveAsync();
            tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool flag =await _iManager.ITripRep.DeleteAsync(id);
            if(flag)
               await _iManager.SaveAsync();
            return flag;
        }
    }
}

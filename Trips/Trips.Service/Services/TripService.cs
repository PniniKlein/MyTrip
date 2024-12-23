using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servises
{
    public class TripService : ITripService
    {
        readonly ITripRepository _iRepository;
        public TripService(ITripRepository iRepository)
        {
            _iRepository = iRepository;
        }
        public List<Trip> Get()
        {
            return _iRepository.Get();
        }
        public List<Trip> GetAll()
        {
            return _iRepository.GetAll();
        }
        public Trip? GetById(int id)
        {
            return _iRepository.GetById(id);
        }

        public Trip Add(Trip trip)
        {
           trip= _iRepository.Add(trip);
            return trip;
        }
        public Trip Update(int id, Trip trip)
        {
            trip=_iRepository.Update(id, trip);
            return trip;
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servises
{
    public class TripService : ITripService
    {
        readonly IRepository<Trip> _iRepository;
        public TripService(IRepository<Trip> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<Trip> Get()
        {
            return _iRepository.Get();
        }
        public Trip? GetById(int id)
        {
            return _iRepository.GetById(id);
        }

        public Trip Add(Trip trip)
        {
            _iRepository.Add(trip);
            return trip;
        }
        public Trip Update(int id, Trip trip)
        {
            _iRepository.Update(id, trip);
            return trip;
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}

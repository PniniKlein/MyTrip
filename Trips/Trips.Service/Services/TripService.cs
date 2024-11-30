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
    public class TripService : Iservice<Trip>
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
        public Trip GetById(int id)
        {
            return _iRepository.GetById(id);
        }

        public bool Add(Trip trip)
        {
            return _iRepository.Add(trip);
        }
        public bool Update(int id, Trip trip)
        {
            return _iRepository.Update(id, trip);
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}

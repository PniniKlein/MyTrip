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
        readonly IRepositoryManager _iManager;
        public TripService(IRepositoryManager iManager)
        {
            _iManager = iManager;
        }
        public List<Trip> Get()
        {
            return _iManager.ITripRep.Get();
        }
        public List<Trip> GetAll()
        {
            return _iManager.ITripRep.GetAll();
        }
        public Trip? GetById(int id)
        {
            return _iManager.ITripRep.GetById(id);
        }

        public Trip Add(Trip trip)
        {
           trip= _iManager.ITripRep.Add(trip);
            if (trip != null)
                _iManager.Save();
            return trip;
        }
        public Trip Update(int id, Trip trip)
        {
            trip= _iManager.ITripRep.Update(id, trip);
            if (trip != null)
                _iManager.Save();
            return trip;
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

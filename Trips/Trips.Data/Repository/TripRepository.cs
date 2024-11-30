using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepository;

namespace Trips.Data.Repository
{
    public class TripRepository:IRepository<Trip>
    {
        readonly DataContext _dataContext;
        public TripRepository(DataContext dataContex)
        {
            _dataContext = dataContex;
        }
        public List<Trip> Get()
        {
            return _dataContext.trips;
        }
        public Trip GetById(int id)
        {
            return _dataContext.trips.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Trip trip)
        {
            _dataContext.trips.Add(new Trip(trip));
            return _dataContext.SaveData<Trip>(_dataContext.trips, "trip.json");
        }
        public bool Update(int id, Trip trip)
        {
            int index = _dataContext.trips.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _dataContext.trips[index] = new Trip(id, trip);
                return _dataContext.SaveData<Trip>(_dataContext.trips, "trip.json");
            }
            return false;
        }
        public bool Delete(int id)
        {
            bool succeed = _dataContext.trips.Remove(_dataContext.trips.FirstOrDefault(x => x.Id == id));
            if (succeed)
                return _dataContext.SaveData<Trip>(_dataContext.trips, "trip.json");
            return false;
        }
    }
}

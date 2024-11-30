using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepository;

namespace Trips.Data.Repository
{
    public class AttractionToTripRepository : IRepository<AttractionToTrip>
    {
        readonly DataContext _dataContext;
        public AttractionToTripRepository(DataContext dataContex)
        {
            _dataContext = dataContex;
        }
        public List<AttractionToTrip> Get()
        {
            return _dataContext.attractionToTrips;
        }
        public AttractionToTrip GetById(int id)
        {
            return _dataContext.attractionToTrips.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(AttractionToTrip attractionToTrip)
        {
            _dataContext.attractionToTrips.Add(new AttractionToTrip(attractionToTrip));
            return _dataContext.SaveData<AttractionToTrip>(_dataContext.attractionToTrips, "attractionToTrip.json");
        }
        public bool Update(int id, AttractionToTrip attractionToTrip)
        {
            int index = _dataContext.attractionToTrips.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _dataContext.attractionToTrips[index] = new AttractionToTrip(id,attractionToTrip);
                return _dataContext.SaveData<AttractionToTrip>(_dataContext.attractionToTrips, "attractionToTrip.json");
            }
            return false;
        }
        public bool Delete(int id)
        {
            bool succeed = _dataContext.attractionToTrips.Remove(_dataContext.attractionToTrips.FirstOrDefault(x => x.Id == id));
            if (succeed)
                return _dataContext.SaveData<AttractionToTrip>(_dataContext.attractionToTrips, "attractionToTrip.json");
            return false;
        }
    }
}

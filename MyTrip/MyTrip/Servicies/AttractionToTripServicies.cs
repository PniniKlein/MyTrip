using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class AttractionToTripServicies
    {
        public List<AttractionToTrip> Get()
        {
            return DataContexManager.data.attractionToTrips;
        }
        public AttractionToTrip GetById(int id)
        {
            return DataContexManager.data.attractionToTrips.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(AttractionToTrip attractionToTrip)
        {
            DataContexManager.data.attractionToTrips.Add(new AttractionToTrip(attractionToTrip));
            return true;
        }
        public bool Update(int id, AttractionToTrip attractionToTrip)
        {
            int index = DataContexManager.data.attractionToTrips.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                DataContexManager.data.attractionToTrips[index] = new AttractionToTrip(id, attractionToTrip);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return DataContexManager.data.attractionToTrips.Remove(DataContexManager.data.attractionToTrips.FirstOrDefault(x => x.Id == id));
        }
    }
}

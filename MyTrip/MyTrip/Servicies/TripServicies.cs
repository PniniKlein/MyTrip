using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class TripServicies
    {
        public List<Trip> Get()
        {
            return DataContexManager.data.trips;
        }
        public Trip GetById(int id)
        {
            return DataContexManager.data.trips.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Trip trip)
        {
            DataContexManager.data.trips.Add(new Trip(trip));
            return true;
        }
        public bool Update(int id, Trip trip)
        {
            int index = DataContexManager.data.trips.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                DataContexManager.data.trips[index] = new Trip(id, trip);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return DataContexManager.data.trips.Remove(DataContexManager.data.trips.FirstOrDefault(x => x.Id == id));
        }
    }
}

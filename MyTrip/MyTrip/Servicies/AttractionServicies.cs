using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class AttractionServicies
    {
        public List<Attraction> Get()
        {
            return DataContexManager.data.attractions;
        }
        public Attraction GetById(int id)
        {
            return DataContexManager.data.attractions.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Attraction attraction)
        {
            DataContexManager.data.attractions.Add(new Attraction(attraction));
            return true;
        }
        public bool Update(int id, Attraction attraction)
        {
            int index = DataContexManager.data.attractions.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                DataContexManager.data.attractions[index] = new Attraction(id, attraction);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return DataContexManager.data.attractions.Remove(DataContexManager.data.attractions.FirstOrDefault(x => x.Id == id));
        }
    }
}

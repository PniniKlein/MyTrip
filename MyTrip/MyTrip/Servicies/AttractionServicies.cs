using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class AttractionServicies
    {
        static List<Attraction> dataAttractions = new List<Attraction>();

        public List<Attraction> Get()
        {
            return dataAttractions;
        }
        public Attraction GetById(int id)
        {
            return dataAttractions.FirstOrDefault(x => x.Id == id);
        }

        public ActionResult<bool> Add(Attraction attraction)
        { 
            dataAttractions.Add(new Attraction(attraction));
            return true;
        }
        public ActionResult<bool> Update(int id,Attraction attraction)
        {
            for (int i = 0; i < dataAttractions.Count; i++)
            {
                if (dataAttractions[i].Id == attraction.Id)
                {
                    dataAttractions[i] = new Attraction(id,attraction);
                    return true;
                }
            }
            return false;
        }
        public ActionResult<bool> Delete(int id)
        {
            return dataAttractions.Remove(dataAttractions.FirstOrDefault(x => x.Id == id));
        }
    }
}

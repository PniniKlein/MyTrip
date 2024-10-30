using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class AttractionToTripServicies
    {
        static List<AttractionToTrip> dataAttractoinToTrip = new List<AttractionToTrip>();

        public List<AttractionToTrip> Get()
        {
            return dataAttractoinToTrip;
        }
        public AttractionToTrip GetById(int id)
        {
            return dataAttractoinToTrip.FirstOrDefault(x => x.Id == id);
        }

        public ActionResult<bool> Add(AttractionToTrip attractionToTrip)
        {
            dataAttractoinToTrip.Add(attractionToTrip);
            return true;
        }
        public ActionResult<bool> Update(AttractionToTrip attractionToTrip)
        {
            for (int i = 0; i < dataAttractoinToTrip.Count; i++)
            {
                if (dataAttractoinToTrip[i].Id == attractionToTrip.Id)
                {
                    dataAttractoinToTrip[i] = new AttractionToTrip(attractionToTrip);
                    return true;
                }
            }
            return false;
        }
        public ActionResult<bool> Delete(int id)
        {
            return dataAttractoinToTrip.Remove(dataAttractoinToTrip.FirstOrDefault(x => x.Id == id));
        }
    }
}

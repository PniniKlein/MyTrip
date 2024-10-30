using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class GuideServicies
    {
        static List<Guide> dataGuides = new List<Guide>();

        public List<Guide> Get()
        {
            return dataGuides;
        }
        public Guide GetById(int id)
        {
            return dataGuides.FirstOrDefault(x => x.Id == id);
        }

        public ActionResult<bool> Add(Guide guide)
        {
            dataGuides.Add(guide);
            return true;
        }
        public ActionResult<bool> Update(Guide guide)
        {
            for (int i = 0; i < dataGuides.Count; i++)
            {
                if (dataGuides[i].Id == guide.Id)
                {
                    dataGuides[i] = new Guide(guide);
                    return true;
                }
            }
            return false;
        }
        public ActionResult<bool> Delete(int id)
        {
            return dataGuides.Remove(dataGuides.FirstOrDefault(x => x.Id == id));
        }
    }
}

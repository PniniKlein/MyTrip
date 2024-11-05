using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class GuideServicies
    {
        public List<Guide> Get()
        {
            return DataContexManager.data.guides;
        }
        public Guide GetById(int id)
        {
            return DataContexManager.data.guides.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Guide guide)
        {
            if (!CorrectTZ(guide.TZ))
                return false;
            DataContexManager.data.guides.Add(new Guide(guide));
            return true;
        }
        public bool Update(int id, Guide guide)
        {
            if (!CorrectTZ(guide.TZ))
                return false;
            int index = DataContexManager.data.guides.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                DataContexManager.data.guides[index] = new Guide(id, guide);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return DataContexManager.data.guides.Remove(DataContexManager.data.guides.FirstOrDefault(x => x.Id == id));
        }
        public bool CorrectTZ(string TZ)
        {
            if (TZ.Length != 9)
                return false;
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                if (TZ[i] < '0' || TZ[i] > '9')
                    return false;
                if (i % 2 == 0)
                    sum += TZ[i] - '0';
                else
                    sum += (TZ[i] - '0') * 2 % 10 + (TZ[i] - '0') * 2 / 10 % 10;
            }
            if (10 - (sum % 10) == TZ[8])
                return true;
            return false;
        }
    }
}

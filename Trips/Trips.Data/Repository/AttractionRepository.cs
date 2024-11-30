using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepository;

namespace Trips.Data.Repository
{
    public class AttractionRepository :IRepository<Attraction>
    {
        readonly DataContext _dataContext;
        public AttractionRepository(DataContext dataContex)
        {
            _dataContext = dataContex;
        }
        public List<Attraction> Get()
        {
            return _dataContext.attractions;
        }
        public Attraction GetById(int id)
        {
            return _dataContext.attractions.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Attraction attraction)
        {
            _dataContext.attractions.Add(new Attraction(attraction));
            return _dataContext.SaveData<Attraction>(_dataContext.attractions, "attraction.json");
        }
        public bool Update(int id, Attraction attraction)
        {
            int index = _dataContext.attractions.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _dataContext.attractions[index] = new Attraction(id,attraction);
                return _dataContext.SaveData<Attraction>(_dataContext.attractions, "attraction.json");
            }
            return false;
        }
        public bool Delete(int id)
        {
            bool succeed = _dataContext.attractions.Remove(_dataContext.attractions.FirstOrDefault(x => x.Id == id));
            if (succeed)
                return _dataContext.SaveData<Attraction>(_dataContext.attractions, "attraction.json");
            return false;
        }
    }
}

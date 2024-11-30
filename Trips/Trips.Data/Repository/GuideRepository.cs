using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepository;

namespace Trips.Data.Repository
{
    public class GuideRepository : IRepository<Guide>
    {
        readonly DataContext _dataContext;
        public GuideRepository(DataContext dataContex)
        {
            _dataContext = dataContex;
        }
        public List<Guide> Get()
        {
            return _dataContext.guides;
        }
        public Guide GetById(int id)
        {
            return _dataContext.guides.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Guide guide)
        {
            _dataContext.guides.Add(new Guide(guide));
            return _dataContext.SaveData<Guide>(_dataContext.guides, "guide.json");
        }
        public bool Update(int id, Guide guide)
        {
            int index = _dataContext.guides.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _dataContext.guides[index] = new Guide(id, guide);
                return _dataContext.SaveData<Guide>(_dataContext.guides, "guide.json");
            }
            return false;
        }
        public bool Delete(int id)
        {
            bool succeed = _dataContext.guides.Remove(_dataContext.guides.FirstOrDefault(x => x.Id == id));
            if (succeed)
                return _dataContext.SaveData<Guide>(_dataContext.guides, "guide.json");
            return false;
        }
    }
}

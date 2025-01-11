using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servises
{
    public class AttractionService: IAttractionService
    {
        readonly IRepositoryManager _iManager;
        public AttractionService(IRepositoryManager iManager)
        {
            _iManager = iManager;
        }
        public List<Attraction> Get()
        {
            return _iManager.IAttractionRep.Get();
        }
        public List<Attraction> GetAll()
        {
            return _iManager.IAttractionRep.GetAll();
        }
        public Attraction? GetById(int id)
        {
            return _iManager.IAttractionRep.GetById(id);
        }

        public Attraction Add(Attraction attraction)
        {
            attraction= _iManager.IAttractionRep.Add(attraction);
            if (attraction!=null)
                _iManager.Save();
            return attraction;
        }
        public Attraction Update(int id, Attraction attraction)
        {
            attraction = _iManager.IAttractionRep.Update(id, attraction);
            if (attraction != null)
                _iManager.Save();
            return attraction;
        }
        public bool Delete(int id)
        {
            bool flag= _iManager.IAttractionRep.Delete(id);
            if (flag)
                _iManager.Save();
            return flag;
        }
    }
}

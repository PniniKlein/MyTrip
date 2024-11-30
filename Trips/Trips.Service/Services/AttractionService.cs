using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servises
{
    public class AttractionService: Iservice<Attraction>
    {
        readonly IRepository<Attraction> _iRepository;
        public AttractionService(IRepository<Attraction> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<Attraction> Get()
        {
            return _iRepository.Get();
        }
        public Attraction GetById(int id)
        {
            return _iRepository.GetById(id);
        }

        public bool Add(Attraction attraction)
        {
            return _iRepository.Add(attraction);
        }
        public bool Update(int id, Attraction attraction)
        {
            return _iRepository.Update(id, attraction);
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}

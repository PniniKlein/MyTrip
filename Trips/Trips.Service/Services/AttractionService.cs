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
    public class AttractionService: IAttractionService
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
        public Attraction? GetById(int id)
        {
            return _iRepository.GetById(id);
        }

        public Attraction Add(Attraction attraction)
        {
            attraction= _iRepository.Add(attraction);
            return attraction;
        }
        public Attraction Update(int id, Attraction attraction)
        {
            attraction = _iRepository.Update(id, attraction);
            return attraction;
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}

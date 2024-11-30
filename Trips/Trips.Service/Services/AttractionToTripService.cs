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
    public class AttractionToTripService : Iservice<AttractionToTrip>
    {
        readonly IRepository<AttractionToTrip> _iRepository;
        public AttractionToTripService(IRepository<AttractionToTrip> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<AttractionToTrip> Get()
        {
            return _iRepository.Get();
        }
        public AttractionToTrip GetById(int id)
        {
            return _iRepository.GetById(id);
        }

        public bool Add(AttractionToTrip attractionToTrip)
        {
            return _iRepository.Add(attractionToTrip);
        }
        public bool Update(int id, AttractionToTrip attractionToTrip)
        {
            return _iRepository.Update(id, attractionToTrip);
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}

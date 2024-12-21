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
    public class AttractionToTripService : IAttractionToTripService
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
        public AttractionToTrip? GetById(int id)
        {
            return _iRepository.GetById(id);
        }

        public AttractionToTrip Add(AttractionToTrip attractionToTrip)
        {
            attractionToTrip= _iRepository.Add(attractionToTrip);
            return attractionToTrip;
        }
        public AttractionToTrip Update(int id, AttractionToTrip attractionToTrip)
        {
            attractionToTrip = _iRepository.Update(id, attractionToTrip);
            return attractionToTrip;
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}

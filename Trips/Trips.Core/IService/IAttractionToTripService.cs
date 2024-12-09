using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface IAttractionToTripService
    {
        List<AttractionToTrip> Get();
        AttractionToTrip GetById(int id);
        AttractionToTrip Add(AttractionToTrip attractionToTrip);
        AttractionToTrip Update(int id, AttractionToTrip attractionToTrip);
        bool Delete(int id);
    }
}

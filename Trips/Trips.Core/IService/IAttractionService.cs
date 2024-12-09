using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface IAttractionService
    {
        List<Attraction> Get();
        Attraction GetById(int id);
        Attraction Add(Attraction attraction);
        Attraction Update(int id, Attraction attraction);
        bool Delete(int id);
    }
}

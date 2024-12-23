using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface ITripService
    {
        List<Trip> Get();
        List<Trip> GetAll();
        Trip GetById(int id);
        Trip Add(Trip trip);
        Trip Update(int id, Trip trip);
        bool Delete(int id);
    }
}

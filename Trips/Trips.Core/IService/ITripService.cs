using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.DTOs;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface ITripService
    {
        List<TripDto> Get();
        List<Trip> GetAll();
        TripDto GetById(int id);
        TripDto Add(TripDto tripDto);
        TripDto Update(int id, TripDto tripDto);
        bool Delete(int id);
    }
}

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
        Task<List<TripDto>> GetAsync();
        Task<List<Trip>> GetAllAsync();
        Task<TripDto> GetByIdAsync(int id);
        Task<TripDto> AddAsync(TripDto tripDto);
        Task<TripDto> UpdateAsync(int id, TripDto tripDto);
        Task<bool> DeleteAsync(int id);
    }
}

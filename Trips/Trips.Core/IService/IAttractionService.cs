using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.DTOs;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface IAttractionService
    {
        Task<List<AttractionDto>> GetAsync();
        Task<List<Attraction>> GetAllAsync();
        Task<AttractionDto> GetByIdAsync(int id);
        Task<AttractionDto> AddAsync(AttractionDto attractionDto);
        Task<AttractionDto> UpdateAsync(int id, AttractionDto attractionDto);
        Task<bool> DeleteAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.DTOs;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface IGuideService
    {
        Task<List<GuideDto>> GetAsync();
        Task<List<Guide>> GetAllAsync();
        Task<GuideDto> GetByIdAsync(int id);
        Task<GuideDto> AddAsync(GuideDto guideDto);
        Task<GuideDto> UpdateAsync(int id, GuideDto guideDto);
        Task<bool> DeleteAsync(int id);
    }
}

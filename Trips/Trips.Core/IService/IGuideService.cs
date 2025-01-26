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
        List<GuideDto> Get();
        List<Guide> GetAll();
        GuideDto GetById(int id);
        GuideDto Add(GuideDto guideDto);
        GuideDto Update(int id, GuideDto guideDto);
        bool Delete(int id);
    }
}

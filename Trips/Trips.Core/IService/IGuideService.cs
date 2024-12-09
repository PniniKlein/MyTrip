using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface IGuideService
    {
        List<Guide> Get();
        Guide GetById(int id);
        Guide Add(Guide guide);
        Guide Update(int id, Guide guide);
        bool Delete(int id);
    }
}

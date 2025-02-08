using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepositories;

namespace Trips.Data.Repository
{
    public class GuideRepository : Repository<Guide>, IGuideRepository
    {
        public GuideRepository(DataContext dataContex) : base(dataContex)
        {
        }
        public async Task<List<Guide>> GetAllAsync()
        {
            return await _dataSet.Include(x => x.trips).ToListAsync();
        }
    }
}

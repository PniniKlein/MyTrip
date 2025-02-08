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
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(DataContext dataContex) : base(dataContex)
        {
        }
        public async Task<List<Trip>> GetAllAsync()
        {
            return await _dataSet.Include(x => x.Guide).Include(x => x.attractions).Include(x => x.orders).ToListAsync();
        }
    }
}

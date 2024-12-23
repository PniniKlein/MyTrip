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
        public TripRepository(DataContext dataContex, IRepositoryManager repositoryManager) : base(dataContex, repositoryManager)
        {
        }
        public List<Trip> GetAll()
        {
            return _dataSet.Include(x => x.Guide).Include(x => x.attractions).Include(x => x.orders).ToList();
        }
    }
}

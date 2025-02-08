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
    public class UserRepository :Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContex ) : base(dataContex)
        {
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _dataSet.Include(x => x.orders).ToListAsync();
        }
    }
}

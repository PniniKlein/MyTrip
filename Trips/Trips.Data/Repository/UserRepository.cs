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
        public List<User> GetAll()
        {
            return _dataSet.Include(x => x.orders).ToList();
        }
    }
}

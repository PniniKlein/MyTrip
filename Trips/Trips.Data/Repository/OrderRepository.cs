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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext dataContex) : base(dataContex)
        {
        }
        public async Task<List<Order>> GetAllAsync()
        {
           return await _dataSet.Include(x => x.User).Include(x => x.Trip).ToListAsync();
        }
     }
}

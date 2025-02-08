using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;

namespace Trips.Core.IRepository
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T user);
        Task<T> UpdateAsync(int id, T user);
        Task<bool> DeleteAsync(int id);
    }
}

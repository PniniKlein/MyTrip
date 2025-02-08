using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.DTOs;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAsync();
        Task<List<User>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> AddAsync(UserDto userDto);
        Task<UserDto> UpdateAsync(int id, UserDto userDto);
        Task<bool> DeleteAsync(int id);
    }
}

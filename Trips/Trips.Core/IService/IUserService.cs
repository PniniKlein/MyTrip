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
        List<UserDto> Get();
        List<User> GetAll();
        UserDto GetById(int id);
        UserDto Add(UserDto userDto);
        UserDto Update(int id, UserDto userDto);
        bool Delete(int id);
    }
}

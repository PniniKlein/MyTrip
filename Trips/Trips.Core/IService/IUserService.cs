using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface IUserService
    {
        List<User> Get();
        List<User> GetAll();
        User GetById(int id);
        User Add(User user);
        User Update(int id, User user);
        bool Delete(int id);
    }
}

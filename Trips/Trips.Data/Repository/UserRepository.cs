using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepository;

namespace Trips.Data.Repository
{
    public class UserRepository: IRepository<User>
    {
        readonly DataContext _dataContext;
        public UserRepository(DataContext dataContex)
        {
            _dataContext = dataContex;
        }
        public List<User> Get()
        {
            return _dataContext.users;
        }
        public User GetById(int id)
        {
            return _dataContext.users.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(User user)
        {
            _dataContext.users.Add(new User(user));
            return _dataContext.SaveData<User>(_dataContext.users, "data.json");
        }
        public bool Update(int id, User user)
        {
            int index = _dataContext.users.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _dataContext.users[index] = new User(id, user);
                return _dataContext.SaveData<User>(_dataContext.users, "data.json");
            }
            return false;
        }
        public bool Delete(int id)
        {
            bool succeed = _dataContext.users.Remove(_dataContext.users.FirstOrDefault(x => x.Id == id));
            if (succeed)
                return _dataContext.SaveData<User>(_dataContext.users, "data.json");
            return false;
        }
    }
}

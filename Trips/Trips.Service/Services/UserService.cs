using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servise
{
    public class UserService : IUserService
    {
        readonly IRepositoryManager _iManager;
        public UserService(IRepositoryManager iManager)
        {
            _iManager = iManager;
        }
        public List<User> Get()
        {
            return _iManager.IUserRep.Get();
        }
        public List<User> GetAll()
        {
            return _iManager.IUserRep.GetAll();
        }
        public User? GetById(int id)
        {
            return _iManager.IUserRep.GetById(id);
        }

        public User Add(User user)
        {
            if (!CorrectTZ(user.TZ))
                return null;
            user= _iManager.IUserRep.Add(user);
            if (user != null)
                _iManager.Save();
            return user;
        }
        public User Update(int id, User user)
        {
            if (!CorrectTZ(user.TZ))
                return null;
            user= _iManager.IUserRep.Update(id, user);
            if (user != null)
                _iManager.Save();
            return user;
        }
        public bool Delete(int id)
        {
            bool flag = _iManager.IUserRep.Delete(id);
            if(flag)
                _iManager.Save();
            return flag;
        }

        public bool CorrectTZ(string TZ)
        {
            if (TZ.Length != 9)
                return false;
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                if (TZ[i] < '0' || TZ[i] > '9')
                    return false;
                if (i % 2 == 0)
                    sum += TZ[i] - '0';
                else
                    sum += (TZ[i] - '0') * 2 % 10 + (TZ[i] - '0') * 2 / 10 % 10;
            }
            if (10 - (sum % 10) == TZ[8] - '0')
                return true;
            return false;
        }
    }
}
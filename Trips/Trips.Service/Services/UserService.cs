using Trips.Core.Entities;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servise
{
    public class UserService : IUserService
    {
        readonly IRepository<User> _iRepository;
        public UserService(IRepository<User> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<User> Get()
        {
            return _iRepository.Get();
        }
        public User? GetById(int id)
        {
            return _iRepository.GetById(id);
        }

        public User Add(User user)
        {
            if (!CorrectTZ(user.TZ))
                return null;
            _iRepository.Add(user);
            return user;
        }
        public User Update(int id, User user)
        {
            if (!CorrectTZ(user.TZ))
                return null;
            _iRepository.Update(id, user);
            return user;
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
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
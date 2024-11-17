using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class UserServicies
    {
        private readonly IDataContex _dateContex;
        public UserServicies(IDataContex dateContex)
        {
            _dateContex = dateContex;
        }
        public List<User> Get()
        {
            _dateContex.LoadData();
            return _dateContex.Users;
        }
        public User GetById(int id)
        {
            _dateContex.LoadData();
            return _dateContex.Users.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(User user)
        {
            if (!CorrectTZ(user.TZ))
                return false;
            _dateContex.LoadData();
            _dateContex.Users.Add(new User(user));
            return _dateContex.SaveData();
        }
        public bool Update(int id, User user)
        {
            if (!CorrectTZ(user.TZ))
                return false;
            _dateContex.LoadData();
            int index = _dateContex.Users.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _dateContex.Users[index] = new User(id, user);
                return _dateContex.SaveData();
            }
            return false;
        }
        public bool Delete(int id)
        {
            _dateContex.LoadData();
            bool succeed=_dateContex.Users.Remove(_dateContex.Users.FirstOrDefault(x => x.Id == id));
            if(succeed)
              return _dateContex.SaveData();
            return false;
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
            if (10 - (sum % 10) == TZ[8]-'0')
                return true;
            return false;
        }
    }
}

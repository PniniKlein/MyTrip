using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class UserServicies
    {
        public List<User> Get()
        {
            return DataContexManager.data.users;
        }
        public User GetById(int id)
        {
            return DataContexManager.data.users.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(User user)
        {
            if (!CorrectTZ(user.TZ))
                return false;
            DataContexManager.data.users.Add(new User(user));
            return true;
        }
        public bool Update(int id, User user)
        {
            if (!CorrectTZ(user.TZ))
                return false;
            int index = DataContexManager.data.users.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                DataContexManager.data.users[index] = new User(id, user);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return DataContexManager.data.users.Remove(DataContexManager.data.users.FirstOrDefault(x => x.Id == id));
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

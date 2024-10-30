using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class UserServicies
    {
        static List<User> dataUsers = new List<User>();
        private static int count = 0;

        public List<User> Get()
        {
            return dataUsers;
        }
        public User GetById(int id)
        {
            return dataUsers.FirstOrDefault(x => x.Id == id);
        }

        public ActionResult<bool> Add(User user)
        {
            dataUsers.Add(new User(count++,user));
            return true;
        }
        public ActionResult<bool> Update(int id,User user)
        {
            for (int i = 0; i < dataUsers.Count; i++)
            {
                if (dataUsers[i].Id==user.Id)
                {
                    dataUsers[i] = new User(id,user);
                    return true;
                }
            }
            return false;
        }
        public ActionResult<bool> Delete(int id)
        {
            return dataUsers.Remove(dataUsers.FirstOrDefault(x => x.Id == id));
        }
    }
}

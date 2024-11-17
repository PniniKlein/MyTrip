using MyTrip.Entities;
using System.Drawing;
using System.Text.Json;

namespace MyTrip.Entities
{
    public class JsonUser : IDataContex
    {
        public List<User> Users { get; set; }

        public void LoadData()
        {
            User.count = 1;
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
            string jsonString = File.ReadAllText(path);
            Console.WriteLine(jsonString);
            Users = JsonSerializer.Deserialize<DataUser>(jsonString).db;
        }

        public bool SaveData()
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
                DataUser dataUser = new DataUser();
                dataUser.db = Users;
                string jsonString = JsonSerializer.Serialize<DataUser>(dataUser);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path, jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

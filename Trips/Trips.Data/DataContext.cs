using System;
using System.Data;
using System.Text.Json;
using Trips.Core.Entities;

namespace Trips.Data
{
    public class DataContext
    {
        public List<Attraction> attractions = new List<Attraction>();
        public List<AttractionToTrip> attractionToTrips = new List<AttractionToTrip>();
        public List<Guide> guides = new List<Guide>();
        public List<Order> orders = new List<Order>();
        public List<Trip> trips = new List<Trip>();
        public List<User> users = new List<User>();

        public DataContext()
        {
            attractions = LoadData<Attraction>("attraction.json");
            attractionToTrips = LoadData<AttractionToTrip>("attractionToTrip.json");
            guides = LoadData<Guide>("guide.json");
            orders = LoadData<Order>("order.json");
            trips = LoadData<Trip>("trip.json");
            users = LoadData<User>("user.json");
        }
        private List<T> LoadData<T>(string pathJson)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", pathJson);
            string jsonString = File.ReadAllText(path);
            List<T> lst = new List<T>();
            lst = JsonSerializer.Deserialize<List<T>>(jsonString);
            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
            return lst;
        }
        public bool SaveData<T>(List<T> lst, string pathJson)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", pathJson);
                string jsonString = JsonSerializer.Serialize<List<T>>(lst);
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
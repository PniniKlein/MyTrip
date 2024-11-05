using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class OrderServicies
    {
        public List<Order> Get()
        {
            return DataContexManager.data.orders;
        }
        public Order GetById(int id)
        {
            return DataContexManager.data.orders.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Order order)
        {
            DataContexManager.data.orders.Add(new Order(order));
            return true;
        }
        public bool Update(int id, Order order)
        {
            int index = DataContexManager.data.orders.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                DataContexManager.data.orders[index] = new Order(id, order);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return DataContexManager.data.orders.Remove(DataContexManager.data.orders.FirstOrDefault(x => x.Id == id));
        }
    }
}

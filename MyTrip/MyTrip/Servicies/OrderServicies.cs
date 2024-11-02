using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class OrderServicies
    {
        static List<Order> dataOrders = new List<Order>();

        public List<Order> Get()
        {
            return dataOrders;
        }
        public Order GetById(int id)
        {
            return dataOrders.FirstOrDefault(x => x.Id == id);
        }

        public ActionResult<bool> Add(Order order)
        {
            dataOrders.Add(new Order(order));
            return true;
        }
        public ActionResult<bool> Update(int id,Order order)
        {
            for (int i = 0; i < dataOrders.Count; i++)
            {
                if (dataOrders[i].Id == order.Id)
                {
                    dataOrders[i] = new Order(id, order);
                    return true;
                }
            }
            return false;
        }
        public ActionResult<bool> Delete(int id)
        {
            return dataOrders.Remove(dataOrders.FirstOrDefault(x => x.Id == id));
        }
    }
}

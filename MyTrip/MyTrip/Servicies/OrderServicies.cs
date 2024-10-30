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
            dataOrders.Add(order);
            return true;
        }
        public ActionResult<bool> Update(Order order)
        {
            for (int i = 0; i < dataOrders.Count; i++)
            {
                if (dataOrders[i].Id == order.Id)
                {
                    dataOrders[i] = new Order(order);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.Entities
{
    public class Order
    {
        static int count = 1;
        public int Id { get; private set; }
        public int TripCode { get; set; }
        public int UserCode { get; set; }
        public int NumOfTickets { get; set; }
        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
        public string Account { get; set; }
        public bool IsPayment { get; set; }
        public Order()
        {

        }

        public Order(int id, Order o)
        {
            Id = id;
            TripCode = o.TripCode;
            UserCode = o.UserCode;
            NumOfTickets = o.NumOfTickets;
            OrderDate = o.OrderDate;
            Price = o.Price;
            Account = o.Account;
            IsPayment = o.IsPayment;
        }
        public Order(Order o)
        {
            Id = count++;
            TripCode = o.TripCode;
            UserCode = o.UserCode;
            NumOfTickets = o.NumOfTickets;
            OrderDate = o.OrderDate;
            Price = o.Price;
            Account = o.Account;
            IsPayment = o.IsPayment;
        }
    }
}

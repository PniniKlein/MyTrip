using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; private set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int NumOfTickets { get; set; }
        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
        public string Account { get; set; }
        public bool IsPayment { get; set; }
        public Order()
        {

        }
        public Order(Order o)
        {
            Id = o.Id;
            TripId = o.TripId;
            UserId = o.UserId;
            NumOfTickets = o.NumOfTickets;
            OrderDate = o.OrderDate;
            Price = o.Price;
            Account = o.Account;
            IsPayment = o.IsPayment;
        }
        //public void Copy(Order order)
        //{
        //    TripCode = order.TripCode!= TripCode?order.TripCode:TripCode;
        //    UserCode = order.UserCode!= UserCode?order.UserCode:UserCode;
        //    NumOfTickets = order.NumOfTickets != NumOfTickets? order.NumOfTickets:NumOfTickets;
        //    OrderDate = order.OrderDate != OrderDate ? order.OrderDate : OrderDate;
        //    Price = order.Price != Price ? order.Price : Price;
        //    Account ??= order.Account;
        //    IsPayment= order.IsPayment != IsPayment ? order.IsPayment : IsPayment;
        //}
    }
}


namespace Trips.API.PostModel
{
    public class OrderPostModel
    {
        public int TripId { get; set; }
        public int UserId { get; set; }
        public int NumOfTickets { get; set; }
        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
        public string Account { get; set; }
        public bool IsPayment { get; set; }
    }
}

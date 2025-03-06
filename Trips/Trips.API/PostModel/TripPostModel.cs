
namespace Trips.API.PostModel
{
    public class TripPostModel
    {
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public int NumOfNights { get; set; }
        public string Country { get; set; }
        public string ItemNeeded { get; set; }
        public string TypeOfTrip { get; set; }
        public string PlaceMeeting { get; set; }
        public int GuideId { get; set; }
        public double Price { get; set; }
        public bool IncludeSleepingAndMeal { get; set; }
    }
}

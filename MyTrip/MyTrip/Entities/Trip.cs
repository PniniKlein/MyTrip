namespace MyTrip.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public int NumOfNights { get; set; }
        public string Country { get; set; }
        public string ItemNeeded { get; set; }
        public string TypeOfTrip { get; set; }
        public string PlaceMeeting { get; set; }
        public int GuideCode { get; set; }
        public double Price { get; set; }
        public bool IncludeSleepingAndMeal { get; set; }
        public Trip()
        {
            
        }

        public Trip(int id,Trip t)
        {
            Id =id;
            DateOfStart = t.DateOfStart;
            DateOfEnd = t.DateOfEnd;
            NumOfNights = t.NumOfNights;
            Country = t.Country;
            ItemNeeded = t.ItemNeeded;
            TypeOfTrip = t.TypeOfTrip;
            PlaceMeeting = t.PlaceMeeting;
            GuideCode = t.GuideCode;
            Price = t.Price;
            IncludeSleepingAndMeal = t.IncludeSleepingAndMeal;
        }
    }
}

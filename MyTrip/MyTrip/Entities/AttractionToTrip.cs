namespace MyTrip.Entities
{
    public class AttractionToTrip
    {
        public int Id { get; set; }
        public int TripCode { get; set; }
        public int AttractionCode { get; set;}
        public AttractionToTrip()
        {
            
        }

        public AttractionToTrip(AttractionToTrip a)
        {
            Id = a.Id;
            TripCode = a.TripCode;
            AttractionCode = a.AttractionCode;
        }
    }
}

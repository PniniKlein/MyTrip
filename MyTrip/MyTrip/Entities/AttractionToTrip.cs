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

        public AttractionToTrip(int id,AttractionToTrip a)
        {
            Id = id;
            TripCode = a.TripCode;
            AttractionCode = a.AttractionCode;
        }
    }
}

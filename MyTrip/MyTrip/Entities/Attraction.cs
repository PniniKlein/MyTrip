namespace MyTrip.Entities
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int[] ImgArray { get; set; }
        public Attraction()
        {
            
        }

        public Attraction(Attraction a)
        {
            Id = a.Id;
            Name = a.Name;
            Place = a.Place;
            Description = a.Description;
            Type = a.Type;
            ImgArray = a.ImgArray;
        }
    }
}

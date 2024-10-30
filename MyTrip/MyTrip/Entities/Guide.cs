namespace MyTrip.Entities
{
    public class Guide
    {
        public int Id { get; set; }
        public int TZ { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }
        public int SalaryToDay { get; set; }
        public Guide()
        {
            
        }

        public Guide(Guide g)
        {
            Id = g.Id;
            TZ = g.TZ;
            Name = g.Name;
            Age = g.Age;
            City = g.City;
            Street = g.Street;
            Phone = g.Phone;
            Email = g.Email;
            Experience = g.Experience;
            SalaryToDay = g.SalaryToDay;
        }
    }
}

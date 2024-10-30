using System.Reflection.Metadata.Ecma335;

namespace MyTrip.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int TZ { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int NumOfPerson { get; set; }
        public User()
        {        
        }

        public User(User u)
        {
            Id = u.Id;
            TZ = u.TZ;
            Name = u.Name;
            Age = u.Age;
            City = u.City;
            Street = u.Street;
            Phone = u.Phone;
            Email = u.Email;
            RegistrationDate = u.RegistrationDate;
            NumOfPerson = u.NumOfPerson;
        }
    }
}

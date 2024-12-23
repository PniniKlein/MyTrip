using System.ComponentModel.DataAnnotations;

namespace Trips.Core.Entities
{
    public class User
    {
        [Key]
        public int Id { get; private set; }
        public string TZ { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int NumOfPerson { get; set; }
        public List<Order> orders { get; set; }
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
        //public void Copy(User user)
        //{
        //    TZ ??= user.TZ;
        //    Name ??= user.Name;
        //    Age = user.Age!=Age ? user.Age : Age;
        //    City ??= user.City;
        //    Street ??= user.Street;
        //    Phone ??= user.Phone;
        //    Email ??= user.Email;
        //    RegistrationDate = user.RegistrationDate!= RegistrationDate? user.RegistrationDate:RegistrationDate;
        //    NumOfPerson = user.NumOfPerson != NumOfPerson ? user.NumOfPerson : NumOfPerson;
        //}
    }
}
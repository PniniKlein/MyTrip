﻿namespace Trips.Core.Entities
{
    public class User
    {
        public static int count = 1;

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
        public User()
        {
            Id = count++;
        }

        public User(int id, User u)
        {
            Id = id;
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
        public User(User u)
        {
            Id = count++;
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
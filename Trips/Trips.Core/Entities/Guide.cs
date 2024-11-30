using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.Entities
{
    public class Guide
    {
        static int count = 1;
        public int Id { get; private set; }
        public string TZ { get; set; }
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

        public Guide(int id, Guide g)
        {
            Id = id;
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
        public Guide(Guide g)
        {
            Id = count++;
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

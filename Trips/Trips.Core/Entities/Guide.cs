using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Trips.Core.Entities
{
    public class Guide
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
        //public void Copy(Guide my,Guide guide)
        //{
        //    my.TZ ??= guide.TZ;
        //    my.Name ??= guide.Name;
        //    my.Age = guide.Age!= my.Age ? guide.Age:Age;
        //    my.City ??= guide.City;
        //    my.Street ??= guide.Street;
        //    my.Phone ??= guide.Phone;
        //    my.Email ??= guide.Email;
        //    my.Experience = guide.Experience!= Experience?guide.Experience:Experience;
        //    my.SalaryToDay = guide.SalaryToDay!=SalaryToDay?guide.SalaryToDay:SalaryToDay;
        //}
    }
}

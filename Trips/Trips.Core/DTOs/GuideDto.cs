using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.DTOs
{
    public class GuideDto
    {
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
    }
}

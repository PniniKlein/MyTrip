using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.DTOs
{
    public class AttractionDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}

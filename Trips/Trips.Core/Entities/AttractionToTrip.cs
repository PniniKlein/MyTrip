using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.Entities
{
    public class AttractionToTrip
    {
        static int count = 1;
        public int Id { get; private set; }
        public int TripCode { get; set; }
        public int AttractionCode { get; set; }
        public AttractionToTrip()
        {

        }

        public AttractionToTrip(int id, AttractionToTrip a)
        {
            Id = id;
            TripCode = a.TripCode;
            AttractionCode = a.AttractionCode;
        }
        public AttractionToTrip(AttractionToTrip a)
        {
            Id = count++;
            TripCode = a.TripCode;
            AttractionCode = a.AttractionCode;
        }
    }
}

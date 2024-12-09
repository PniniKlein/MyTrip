using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.Entities
{
    public class AttractionToTrip
    {
        [Key]
        public int Id { get; private set; }
        public int TripCode { get; set; }
        public int AttractionCode { get; set; }
        public AttractionToTrip()
        {

        }
        public AttractionToTrip(AttractionToTrip a)
        {
            Id = a.Id;
            TripCode = a.TripCode;
            AttractionCode = a.AttractionCode;
        }
        //public void Copy(AttractionToTrip my, AttractionToTrip attractionToTrip)
        //{
        //    if(my.TripCode != attractionToTrip.TripCode)
        //        my.TripCode = attractionToTrip.TripCode;
        //    if(my.AttractionCode != attractionToTrip.AttractionCode)
        //        my.AttractionCode = attractionToTrip.AttractionCode;
        //}
    }
}

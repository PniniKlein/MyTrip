using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.Entities
{
    public class Trip
    {
        [Key]
        public int Id { get; private set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public int NumOfNights { get; set; }
        public string Country { get; set; }
        public string ItemNeeded { get; set; }
        public string TypeOfTrip { get; set; }
        public string PlaceMeeting { get; set; }
        public int GuideCode { get; set; }
        public double Price { get; set; }
        public bool IncludeSleepingAndMeal { get; set; }
        public Trip()
        {

        }
        public Trip(Trip t)
        {
            Id = t.Id;
            DateOfStart = t.DateOfStart;
            DateOfEnd = t.DateOfEnd;
            NumOfNights = t.NumOfNights;
            Country = t.Country;
            ItemNeeded = t.ItemNeeded;
            TypeOfTrip = t.TypeOfTrip;
            PlaceMeeting = t.PlaceMeeting;
            GuideCode = t.GuideCode;
            Price = t.Price;
            IncludeSleepingAndMeal = t.IncludeSleepingAndMeal;
        }
        //public void Copy(Trip trip)
        //{
        //    DateOfStart= trip.DateOfStart!= DateOfStart?trip.DateOfStart:DateOfStart;
        //    DateOfEnd = trip.DateOfEnd != DateOfEnd?trip.DateOfEnd:DateOfEnd;
        //    NumOfNights = trip.NumOfNights != NumOfNights?trip.NumOfNights:NumOfNights;
        //    Country ??= trip.Country;
        //    ItemNeeded ??= trip.ItemNeeded;
        //    TypeOfTrip ??= trip.TypeOfTrip;
        //    PlaceMeeting ??= trip.PlaceMeeting;
        //    GuideCode = trip.GuideCode!=GuideCode?trip.GuideCode: GuideCode;
        //    Price = trip.Price != Price? trip.Price : Price;
        //    IncludeSleepingAndMeal = trip.IncludeSleepingAndMeal!= IncludeSleepingAndMeal?trip.IncludeSleepingAndMeal:IncludeSleepingAndMeal;
        //}
    }
}

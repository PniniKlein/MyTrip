using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.Entities
{
    public class Attraction
    {
        static int count = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        //public byte ImgArray { get; set; }
        public Attraction()
        {

        }

        public Attraction(int id, Attraction a)
        {
            Id = id;
            Name = a.Name;
            Place = a.Place;
            Description = a.Description;
            Type = a.Type;
            //ImgArray = a.ImgArray;
        }

        public Attraction(Attraction a)
        {
            Id = count++;
            Name = a.Name;
            Place = a.Place;
            Description = a.Description;
            Type = a.Type;
            //ImgArray = a.ImgArray;
        }
    }
}

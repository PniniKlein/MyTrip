using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.Entities
{
    public class Attraction
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public List<Trip> trips { get; set; }
        //public byte ImgArray { get; set; }
        public Attraction()
        {

        }

        //public void Copy(Attraction my, Attraction t)
        //{
        //    my.Name ??= t.Name;
        //    my.Place ??= t.Place;
        //    my.Description ??= t.Description;
        //    my.Type ??= t.Type;
        //}

        public Attraction(Attraction a)
        {
            Id = a.Id;
            Name = a.Name;
            Place = a.Place;
            Description = a.Description;
            Type = a.Type;
            //ImgArray = a.ImgArray;
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.DTOs;
using Trips.Core.Entities;

namespace Trips.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Attraction,AttractionDto>().ReverseMap();
            CreateMap<Guide,GuideDto>().ReverseMap();
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<Trip,TripDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}

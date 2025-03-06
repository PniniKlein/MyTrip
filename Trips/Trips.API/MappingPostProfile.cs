using AutoMapper;
using Trips.API.PostModel;
using Trips.Core.DTOs;

namespace Trips.API
{
    public class MappingPostProfile:Profile
    {
        public MappingPostProfile()
        {
            CreateMap<AttractionPostModel,AttractionDto>();
            CreateMap<GuidePostModel,GuideDto>();
            CreateMap<OrderPostModel,OrderDto>();
            CreateMap<TripPostModel,TripDto>();
            CreateMap<UserPostModel, UserDto>();
        }
    }
}

using AutoMapper;
using ItCareerExam.Data.Models;
using ItCareerExam.Service.Models;

namespace ItCareerExam.Service.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppUser, UserDto>();
        CreateMap<AppUser, UserEditDto>();
        CreateMap<Restaurant, RestaurantDto>();
        CreateMap<Review,  ReviewDto>();
    }
}

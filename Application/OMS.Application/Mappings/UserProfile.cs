using AutoMapper;
using OMS.Application.Features.Users.Dtos;

namespace OMS.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // Entity to DTO
        CreateMap<Domain.Entities.User, UserDto>();
    }
}
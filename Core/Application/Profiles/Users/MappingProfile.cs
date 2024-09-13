using Application.Features.Users.Commands.CreateUser;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles.Users;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommand, User>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();

        CreateMap<Geo, GeoDto>().ReverseMap();
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
    }
}
using AutoMapper;
using TalentAI.Application.Features.Auth.DTOs;
using TalentAI.Domain.Entities.Identity;

namespace TalentAI.Application.Mappings;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<User, AuthResponseDto>()
            .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.Id))

            .ForMember(
                dest => dest.AccessToken,
                opt => opt.Ignore())

            .ForMember(
                dest => dest.RefreshToken,
                opt => opt.Ignore())

            .ForMember(
                dest => dest.Roles,
                opt => opt.Ignore());

        CreateMap<User, CurrentUserDto>()
            .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.Id))

            .ForMember(
                dest => dest.Roles,
                opt => opt.MapFrom(src =>
                    src.UserRoles.Select(role => role.Role.Name)));
    }
}
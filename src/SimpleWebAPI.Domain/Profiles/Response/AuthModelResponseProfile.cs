using AutoMapper;
using SimpleWebAPI.Domain.Models;
using SimpleWebAPI.Domain.Models.Response;

namespace SimpleWebAPI.Domain.Profiles.Request
{
    public class AuthModelResponseProfile : Profile
    {
        public AuthModelResponseProfile()
        {
            CreateMap<AuthModel, AuthModelResponse>()
                .ForMember(d => d.Token, o => o.MapFrom(p => p.Token))
                .ForMember(d => d.RefreshTokens, o => o.MapFrom(p => p.RefreshTokens));
        }
    }
}
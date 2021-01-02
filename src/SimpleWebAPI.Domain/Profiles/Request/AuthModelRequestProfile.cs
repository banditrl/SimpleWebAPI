using AutoMapper;
using SimpleWebAPI.Domain.Models;
using SimpleWebAPI.Domain.Models.Request;

namespace SimpleWebAPI.Domain.Profiles.Request
{
    public class AuthModelRequestProfile : Profile
    {
        public AuthModelRequestProfile()
        {
            CreateMap<AuthModelRequest, AuthModel>()
                .ForMember(d => d.Username, o => o.MapFrom(p => p.Username))
                .ForMember(d => d.Password, o => o.MapFrom(p => p.Password))
                .ForMember(d => d.Token, o => o.MapFrom(p => p.Token));
        }
    }
}
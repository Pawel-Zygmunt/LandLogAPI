using AutoMapper;
using LandLogAPI.Dtos;
using LandLogAPI.Entities;

namespace LandLogAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProjectRequest, Project>();
        }
    }
}

using AutoMapper;
using EFCoreIntroduction.DTOs;
using EFCoreIntroduction.Entities;

namespace EFCoreIntroduction.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GenreCreationDTO, Genre>();
            CreateMap<ActorCreationDTO, Actor>();
        }
    }
}
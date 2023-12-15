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
            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(ent => ent.Genres, // ent: 
                                              // configuração especial para o mapeamento da propriedades genres de movie
                                              // field: cada campo do DTO
                dto => dto.MapFrom(field => field.Genres.Select(
                    id => new Genre() { Id = id }
                )));

            CreateMap<MovieActorCreationDTO, MovieActor>();
        }
    }
}
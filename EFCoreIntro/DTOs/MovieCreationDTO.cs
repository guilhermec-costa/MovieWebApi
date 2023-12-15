using EFCoreIntroduction.Entities;

namespace EFCoreIntroduction.DTOs
{
    public class MovieCreationDTO
    {
        public string Title { get; set; }
        public bool InTheaters { get; set; }
        public DateTime Release_at { get; set; }
        public List<Guid> Genres { get; set; } = new();
        public List<MovieActorCreationDTO> MoviesActors { get; set; } = new();
    }

    public class MovieActorCreationDTO
    {
        public Guid ActorId { get; set; }
        public string Character { get; set; }
    }
}
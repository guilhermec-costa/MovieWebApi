using System.ComponentModel.DataAnnotations;

namespace EFCoreIntroduction.Entities
{
    public class MovieActor
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }

    }
}
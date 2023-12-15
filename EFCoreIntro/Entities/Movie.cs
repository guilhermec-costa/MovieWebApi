using System.ComponentModel.DataAnnotations;

namespace EFCoreIntroduction.Entities
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool InTheaters { get; set; }
        public DateTime Release_at { get; set; }
        public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>();
        public HashSet<Genre> Genres { get; set; } = new HashSet<Genre>();
        public List<MovieActor> MoviesActors { get; set; } = new List<MovieActor>();
    }
}
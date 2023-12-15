using System.ComponentModel.DataAnnotations;

namespace EFCoreIntroduction.Entities
{
    public class Actor
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Fortune { get; set; }
        public DateTime DateOfBirth { get; set; }
        public HashSet<MovieActor> MoviesActors = new HashSet<MovieActor>();
    }
}
using System.ComponentModel.DataAnnotations;

namespace EFCoreIntroduction.DTOs
{
    public class ActorCreationDTO
    {
        public string Name { get; set; }
        public decimal Fortune { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> Genres = new();
    }
}
using System.ComponentModel.DataAnnotations;

namespace EFCoreIntroduction.Entities
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
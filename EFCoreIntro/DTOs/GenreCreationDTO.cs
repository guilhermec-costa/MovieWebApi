using System.ComponentModel.DataAnnotations;

namespace EFCoreIntroduction.DTOs
{
    public class GenreCreationDTO
    {
        [StringLength(maximumLength: 150)]
        public string Name { get; set; }
    }
}
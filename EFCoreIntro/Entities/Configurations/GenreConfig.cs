using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreIntroduction.Entities.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);
            builder.HasIndex(g => g.Name).IsUnique(true);
        }
    }
}
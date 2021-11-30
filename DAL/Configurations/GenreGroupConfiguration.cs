using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
	class GenreGroupConfiguration : IEntityTypeConfiguration<GenreGroup>
    {
        public void Configure(EntityTypeBuilder<GenreGroup> builder)
        {
            builder.HasKey(gg => new { gg.GenreId, gg.GroupId });

            builder.HasOne(gg => gg.Group)
				   .WithMany(g => g.GenreGroups)
				   .HasForeignKey(gg => gg.GroupId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(gm => gm.Genre)
				   .WithMany(g => g.GenreGroups)
				   .HasForeignKey(gm => gm.GenreId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
             new GenreGroup
             {
                 GenreId = 1,
                 GroupId = 1
             },
             new GenreGroup
             {
                 GenreId = 2,
                 GroupId = 1
             },
             new GenreGroup
             {
                 GenreId = 3,
                 GroupId = 1
             });

        }
    }
}

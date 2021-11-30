using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
	class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
             new Genre
             {
                 Id = 1,
                 Name = "Hard rock",
                 Description = "Hard rock is a form of loud, aggressive rock music."
             },
             new Genre
             {
                 Id = 2,
                 Name = "Blues rock",
                 Description = "Blues rock is a fusion music genre that combines elements of blues and rock music."
             },
             new Genre
             {
                 Id = 3,
                 Name = "Heavy metal",
                 Description = "Heavy metal is a genre of rock music that developed in the late 1960s and early 1970s."
             });
        }
    }
}

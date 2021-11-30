using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
	class GenreMusicianConfiguration : IEntityTypeConfiguration<GenreMusician>
	{
		public void Configure(EntityTypeBuilder<GenreMusician> builder)
		{
			builder.HasKey(gm => new { gm.GenreId, gm.MusicianId});

			builder.HasOne(gm => gm.Musician)
				   .WithMany(m => m.GenreMusicians)
				   .HasForeignKey(gm => gm.MusicianId);

			builder.HasOne(gm => gm.Genre)
				   .WithMany(g => g.GenreMusicians)
				   .HasForeignKey(gm => gm.GenreId);

			builder.HasData(
			 new GenreMusician
			 {
				 GenreId = 1,
				 MusicianId = 1
			 },
			 new GenreMusician
			 {
				 GenreId = 2,
				 MusicianId = 2
			 },
			 new GenreMusician
			 {
				 GenreId = 2,
				 MusicianId = 3
			 },
			 new GenreMusician
			 {
				 GenreId = 1,
				 MusicianId = 4
			 },
			 new GenreMusician
			 {
				 GenreId = 1,
				 MusicianId = 5
			 },
			 new GenreMusician
			 {
				 GenreId = 3,
				 MusicianId = 6
			 },
			 new GenreMusician
			 {
				 GenreId = 3,
				 MusicianId = 7
			 },
			 new GenreMusician
			 {
				 GenreId = 3,
				 MusicianId = 8
			 });


		}
	}
}

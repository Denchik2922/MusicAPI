using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
	class GenreSongConfiguration : IEntityTypeConfiguration<GenreSong>
	{
		public void Configure(EntityTypeBuilder<GenreSong> builder)
		{

			builder.HasKey(gs => new { gs.GenreId, gs.SongId });

			builder.HasOne(gs => gs.Song)
				   .WithMany(s => s.GenreSongs)
				   .HasForeignKey(gs => gs.SongId);

			builder.HasOne(gs => gs.Genre)
				   .WithMany(g => g.GenreSongs)
				   .HasForeignKey(gs => gs.GenreId);


			builder.HasData(
			 new GenreSong
			 {
				 GenreId = 1,
				 SongId = 1
			 },
			 new GenreSong
			 {
				 GenreId = 2,
				 SongId = 2
			 },
			 new GenreSong
			 {
				 GenreId = 2,
				 SongId = 3
			 });

		}
	}
}

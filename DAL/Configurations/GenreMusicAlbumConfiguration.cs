using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
	class GenreMusicAlbumConfiguration : IEntityTypeConfiguration<GenreMusicAlbum>
	{
		public void Configure(EntityTypeBuilder<GenreMusicAlbum> builder)
		{
            builder.HasKey(gm => new { gm.GenreId, gm.MusicAlbumId });

            builder.HasOne(ga => ga.MusicAlbum)
				   .WithMany(a => a.GenreMusicAlbums)
				   .HasForeignKey(ga => ga.MusicAlbumId);

			builder.HasOne(ga => ga.Genre)
				   .WithMany(g => g.GenreMusicAlbums)
				   .HasForeignKey(ga => ga.GenreId);

			builder.HasData(
			 new GenreMusicAlbum
			 {
				 GenreId = 1,
				 MusicAlbumId = 1
			 },
			 new GenreMusicAlbum
			 {
				 GenreId = 2,
				 MusicAlbumId = 1
			 });

		}
	}
}

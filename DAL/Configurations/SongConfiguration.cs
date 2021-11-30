using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;

namespace DAL.Configurations
{
	class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
			builder.HasData(
			 new Song
			 {
				 Id = 1,
				 Name = "Hells Bells",
				 Released = new DateTime(1980, 10, 31),
				 Length = new TimeSpan(0, 5, 12),
				 MusicAlbumId = 1
			 },
			 new Song
			 {
				 Id = 2,
				 Name = "Shoot to Thrill",
				 Released = new DateTime(1980, 6, 25),
				 Length = new TimeSpan(0, 5, 17),
				 MusicAlbumId = 1
			 },
			 new Song
			 {
				 Id = 3,
				 Name = "Given the Dog a Bone",
				 Released = new DateTime(1980, 8, 25),
				 Length = new TimeSpan(0, 5, 10),
				 MusicAlbumId = 1
			 });
		}
    }
}

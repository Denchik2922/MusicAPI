using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;

namespace DAL.Configurations
{
	class MusicAlbumConfiguration : IEntityTypeConfiguration<MusicAlbum>
    {
        public void Configure(EntityTypeBuilder<MusicAlbum> builder)
        {
			builder.HasData(
			 new MusicAlbum
			 {
				 Id = 1,
				 Name = "Back in Black",
				 Released = new DateTime(1980, 01, 25),
				 Length = new TimeSpan(23, 59, 0),
				 GroupId = 1
			 });
		}
    }
}

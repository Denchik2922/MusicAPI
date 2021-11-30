using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
	class MusicianInstrumentConfiguration : IEntityTypeConfiguration<MusicInstrumentMusician>
	{
		public void Configure(EntityTypeBuilder<MusicInstrumentMusician> builder)
		{
			builder.HasKey(mm => new { mm.MusicInstrumentId, mm.MusicianId });

			builder.HasOne(im => im.Musician)
				   .WithMany(m => m.MusicInstrumentMusicians)
				   .HasForeignKey(im => im.MusicianId);

			builder.HasOne(im => im.MusicInstrument)
				   .WithMany(i => i.MusicInstrumentMusicians)
				   .HasForeignKey(im => im.MusicInstrumentId);

			builder.HasData(
			 new MusicInstrumentMusician
			 {
				MusicInstrumentId = 1,
				MusicianId = 1
			 },
			 new MusicInstrumentMusician
			 {
				 MusicInstrumentId = 1,
				 MusicianId = 2
			 },
			 new MusicInstrumentMusician
			 {
				 MusicInstrumentId = 1,
				 MusicianId = 3
			 },
			 new MusicInstrumentMusician
			 {
				 MusicInstrumentId = 2,
				 MusicianId = 3
			 },
			 new MusicInstrumentMusician
			 {
				 MusicInstrumentId = 2,
				 MusicianId = 4
			 },
			 new MusicInstrumentMusician
			 {
				 MusicInstrumentId = 3,
				 MusicianId = 5
			 },
			 new MusicInstrumentMusician
			 {
				 MusicInstrumentId = 4,
				 MusicianId = 5
			 },
			 new MusicInstrumentMusician
			 {
				 MusicInstrumentId = 5,
				 MusicianId = 6
			 },
			 new MusicInstrumentMusician
			 {
				 MusicInstrumentId = 1,
				 MusicianId = 7
			 },
			 new MusicInstrumentMusician
			 {
				 MusicInstrumentId = 3,
				 MusicianId = 8
			 });


		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
	class InstrumentConfiguration : IEntityTypeConfiguration<MusicInstrument>
    {
        public void Configure(EntityTypeBuilder<MusicInstrument> builder)
        {
            builder.HasData(
             new MusicInstrument
             {
                 Id = 1,
                 Name = "Gitar",
                 Description = "music instrument"
             },
            new MusicInstrument
            {
                Id = 2,
                Name = "Violet",
                Description = "music instrument"
            },
            new MusicInstrument
            {
                Id = 3,
                Name = "Drums",
                Description = "music instrument"
            },
            new MusicInstrument
            {
                Id = 4,
                Name = "Bass guitar",
                Description = "music instrument"
            },
            new MusicInstrument
            {
                Id = 5,
                Name = "Vocal",
                Description = "music instrument"
            });

        }
    }
}

using AutoMapper;
using Models;
using ModelsDto.MusicDto;
using System.Linq;


namespace MusicAPI.Infrastructure.Profiles
{
	public class MusicianProfile : Profile
	{
		public MusicianProfile()
		{
			CreateMap<Musician, Musician>();
			CreateMap<Musician, MusicianDto>();
			CreateMap<MusicianDto, Musician>();

			CreateMap<Musician, MusicianDetailsDto>()
				.ForMember(dest => dest.MusicInstruments, opt => opt.MapFrom(src => src.MusicInstrumentMusicians.Select(i => i.MusicInstrument)))
				.ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.GenreMusicians.Select(g => g.Genre)));
			CreateMap<MusicianDetailsDto, Musician>()
			   .ForMember(musician => musician.MusicInstrumentMusicians, opt => opt
					.MapFrom(musicianDto => musicianDto.MusicInstruments.Select(i => new MusicInstrumentMusician{ MusicInstrumentId = i.Id })))
			   .ForMember(musician => musician.GenreMusicians, opt => opt
					 .MapFrom(musicianDto => musicianDto.Genres.Select(g => new GenreMusician { GenreId = g.Id })));
		}
	}
}

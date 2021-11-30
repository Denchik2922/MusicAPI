using AutoMapper;
using Models.ConcertAPI;
using ModelsDto.ConcertApiDto;

namespace MusicAPI.Infrastructure.Profiles
{
	public class ConcertProfile : Profile
	{
		public ConcertProfile()
		{
			CreateMap<Concert, ConcertDto>().ReverseMap();

			CreateMap<Stat, StatDto>().ReverseMap();

			CreateMap<Venue, VenueDto>().ReverseMap();

		}
	}
}

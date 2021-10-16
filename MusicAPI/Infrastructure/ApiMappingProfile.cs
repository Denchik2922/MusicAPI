using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Models;
using MusicAPI.ModelsDTO;

namespace MusicAPI.infrastructure
{
	public class ApiMappingProfile : Profile
	{
		public ApiMappingProfile()
		{
			CreateMap<Musician, MusicianDTO>().ReverseMap();

			CreateMap<Genre, GenreDTO>().ReverseMap();

			CreateMap<Group, GroupDTO>().ReverseMap();

			CreateMap<MusicAlbum, MusicAlbumDTO>().ReverseMap();

			CreateMap<MusicInstrument, MusicInstrumentDTO>().ReverseMap();

			CreateMap<Song, SongDTO>().ReverseMap();

			CreateMap<Concert, ConcertDTO>().ReverseMap();

			CreateMap<Stat, StatDTO>().ReverseMap();

			CreateMap<Venue, VenueDTO>().ReverseMap();
		}
	}
}

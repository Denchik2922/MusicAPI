using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Models;
using ModelsDto;

namespace MusicAPI.infrastructure
{
	public class ApiMappingProfile : Profile
	{
		public ApiMappingProfile()
		{
			CreateMap<Musician, MusicianDto>().ReverseMap();

			CreateMap<Genre, GenreDto>().ReverseMap();

			CreateMap<Group, GroupDto>().ReverseMap();

			CreateMap<MusicAlbum, MusicAlbumDto>().ReverseMap();

			CreateMap<MusicInstrument, MusicInstrumentDto>().ReverseMap();

			CreateMap<Song, SongDto>().ReverseMap();

			CreateMap<Concert, ConcertDto>().ReverseMap();

			CreateMap<Stat, StatDto>().ReverseMap();

			CreateMap<Venue, VenueDto>().ReverseMap();

			CreateMap<IdentityUser, UserDto>().ReverseMap();

			CreateMap<IdentityUser, UserRegisterDto>().ReverseMap();

		}
	}
}

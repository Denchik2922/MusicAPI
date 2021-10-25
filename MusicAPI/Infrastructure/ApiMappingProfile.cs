using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Models;
using MusicAPI.ModelsDto;

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

			CreateMap<User, UserDto>().ReverseMap();

			CreateMap<User, UserRegisterDto>().ReverseMap();

			CreateMap<Role, RoleDto>().ReverseMap();
		}
	}
}

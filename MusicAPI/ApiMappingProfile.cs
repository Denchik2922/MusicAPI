using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Models;
using Models.ModelsDTO;

namespace MusicAPI
{
	public class ApiMappingProfile : Profile
	{
		public ApiMappingProfile()
		{
			CreateMap<Musician, MusicianDTO>();

			CreateMap<Genre, GenreDTO>();

			CreateMap<Group, GroupDTO>();

			CreateMap<MusicAlbum, MusicAlbumDTO>();

			CreateMap<MusicInstrument, MusicInstrumentDTO>();

			CreateMap<Song, SongDTO>();
		}
	}
}

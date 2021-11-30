using AutoMapper;
using Models;
using ModelsDto.MusicDto;
using System.Linq;

namespace MusicAPI.Infrastructure.Profiles
{
	public class AlbumProfile : Profile
	{
		public AlbumProfile()
		{
			CreateMap<MusicAlbum, MusicAlbum>();
			CreateMap<MusicAlbum, MusicAlbumDto>();
			CreateMap<MusicAlbumDto, MusicAlbum>();

			CreateMap<MusicAlbum, AlbumDetailsDto>()
				.ForMember(ausicAlbumDto => ausicAlbumDto.Genres, ausicAlbum => ausicAlbum.MapFrom(sg => sg.GenreMusicAlbums.Select(g => g.Genre)));
			CreateMap<AlbumDetailsDto, MusicAlbum>()
			   .ForMember(ausicAlbum => ausicAlbum.GenreMusicAlbums, opt => opt
					 .MapFrom(ausicAlbumDto => ausicAlbumDto.Genres.Select(g => new GenreMusicAlbum { GenreId = g.Id })));
		}
	}
}

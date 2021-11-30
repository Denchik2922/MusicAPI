using AutoMapper;
using Models;
using ModelsDto.MusicDto;
using System.Linq;

namespace MusicAPI.Infrastructure.Profiles
{
	public class SongProfile : Profile
	{
		public SongProfile()
		{
			CreateMap<Song, Song>();
			CreateMap<Song, SongDto>();
			CreateMap<SongDto, Song>();
			CreateMap<Song, SongDetailsDto>()
				.ForMember(songDto => songDto.Genres, song => song.MapFrom(sg => sg.GenreSongs.Select(g => g.Genre)));
			CreateMap<SongDetailsDto, Song>()
			   .ForMember(song => song.GenreSongs, opt => opt
					 .MapFrom(songDto => songDto.Genres.Select(g => new GenreSong { GenreId = g.Id })));
		}
	}
}

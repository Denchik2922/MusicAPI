using AutoMapper;
using Models;
using ModelsDto.MusicDto;

namespace MusicAPI.Infrastructure.Profiles
{
	public class GenreProfile : Profile
	{
		public GenreProfile()
		{
			CreateMap<GenreDto, Genre>();
			CreateMap<Genre, GenreDto>();
		}
	}
}

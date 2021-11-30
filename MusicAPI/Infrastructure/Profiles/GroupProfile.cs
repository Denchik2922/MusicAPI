using AutoMapper;
using Models;
using ModelsDto.MusicDto;
using System.Linq;

namespace MusicAPI.Infrastructure.Profiles
{
	public class GroupProfile : Profile
	{
		public GroupProfile()
		{
			CreateMap<Group, Group>();
			CreateMap<Group, GroupDto>();
			CreateMap<GroupDto, Group>();

			CreateMap<Group, GroupDetailsDto>()
				.ForMember(groupDto => groupDto.Genres, group => group.MapFrom(sg => sg.GenreGroups.Select(g => g.Genre)));
			CreateMap<GroupDetailsDto, Group>()
			   .ForMember(group => group.GenreGroups, opt => opt
					 .MapFrom(groupDto => groupDto.Genres.Select(g => new GenreGroup { GenreId = g.Id })));
		}
	}
}

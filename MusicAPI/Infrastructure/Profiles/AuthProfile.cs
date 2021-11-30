using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ModelsDto.AuthDto;

namespace MusicAPI.Infrastructure.Profiles
{
	public class AuthProfile : Profile
	{
		public AuthProfile()
		{
			CreateMap<IdentityUser, UserDto>().ReverseMap();

			CreateMap<IdentityUser, UserRegisterDto>().ReverseMap();
		}
	}
}

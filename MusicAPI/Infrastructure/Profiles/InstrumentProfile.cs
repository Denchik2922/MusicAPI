using AutoMapper;
using Models;
using ModelsDto.MusicDto;

namespace MusicAPI.Infrastructure.Profiles
{
	public class InstrumentProfile : Profile
	{
		public InstrumentProfile()
		{
			CreateMap<MusicInstrumentDto, MusicInstrument>();
			CreateMap<MusicInstrument, MusicInstrumentDto>();
		}
	}
}

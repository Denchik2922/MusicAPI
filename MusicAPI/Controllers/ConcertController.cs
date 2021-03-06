using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelsDto.ConcertApiDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ConcertController : ControllerBase
	{
		private readonly IConcertService _concertApi;
		private readonly IMapper _mapper;

		public ConcertController(IConcertService concertApi, IMapper mapper) 
		{
			_concertApi = concertApi;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllConcerts()
		{
			var concerts = await _concertApi.GetAllConcertsWithInclude();
			if (concerts == null)
			{
				return NotFound();
			}
			List<ConcertDto> concertsDto = _mapper.Map<List<ConcertDto>>(concerts);

			return Ok(concertsDto);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAllConcerts(int id)
		{
			var concert = await _concertApi.GetByIdWithInclude(id);
			if (concert == null)
			{
				return NotFound();
			}
			ConcertDto concertDto = _mapper.Map<ConcertDto>(concert);
			return Ok(concertDto);
		}
	}
}

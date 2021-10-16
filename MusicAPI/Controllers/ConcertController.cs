using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
			List<ConcertDTO> concertsDto = _mapper.Map<List<ConcertDTO>>(concerts);

			return Ok(concertsDto);
		}

		[HttpGet("{id}")]
		public IActionResult GetAllConcerts(int id)
		{
			var concert = _concertApi.GetByIdWithInclude(id);
			ConcertDTO concertDto = _mapper.Map<ConcertDTO>(concert);

			return Ok(concertDto);
		}
	}
}

using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using MusicAPI.ModelsDto;
using System.Collections.Generic;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MusicInstrumentController : ControllerBase
	{
		private readonly IGenericService<MusicInstrument> _instrumentService;
		private readonly IMapper _mapper;

		public MusicInstrumentController(IGenericService<MusicInstrument> instrumentService, IMapper mapper)
		{
			_instrumentService = instrumentService;
			_mapper = mapper;
		}

		/// <summary>
		/// Get all instruments
		/// </summary>
		/// <returns>List instruments</returns>
		[HttpGet]
		public IActionResult GetAllInstruments()
		{
			var instruments = _instrumentService.GetAll();
			if (instruments == null)
			{
				return NotFound();
			}
			var instrumenstDto = _mapper.Map<IEnumerable<MusicInstrumentDto>>(instruments);
			return Ok(instrumenstDto);
		}

		/// <summary>
		/// Get instrument by id
		/// </summary>
		/// <returns>Instrument</returns>
		[HttpGet("{id}")]
		public IActionResult GetInstrumentById(int id)
		{
			var instrument = _instrumentService.GetById(id);
			if (instrument == null)
			{
				return NotFound();
			}
			MusicInstrumentDto instrumentDto = _mapper.Map<MusicInstrumentDto>(instrument);
			return Ok(instrumentDto);
		}


		/// <summary>
		/// Add instrument
		/// </summary>
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public IActionResult AddInstrument(MusicInstrumentDto instrumentDto)
		{
			MusicInstrument instrument = _mapper.Map<MusicInstrument>(instrumentDto);
			_instrumentService.Add(instrument);
			return Ok("Instrument added");
		}

		/// <summary>
		/// Remove instrument
		/// </summary>
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public IActionResult RemoveInstrument(int id)
		{

			_instrumentService.RemoveById(id);
			return Ok("Instrument removed");
		}

		/// <summary>
		/// Update instrument
		/// </summary>
		[HttpPut]
		[Authorize(Roles = "Admin")]
		public IActionResult UpdateSong(MusicInstrumentDto instrumentDto)
		{
			MusicInstrument instrument = _mapper.Map<MusicInstrument>(instrumentDto);
			_instrumentService.Update(instrument);
			return Ok("Instrument updated");
		}
	}
}


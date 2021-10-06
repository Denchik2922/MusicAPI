using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ModelsDTO;
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
			return Ok(_instrumentService.GetAll());
		}

		/// <summary>
		/// Get instrument by id
		/// </summary>
		/// <returns>Instrument</returns>
		[HttpGet("{id}")]
		public IActionResult GetInstrumentById(int id)
		{
			var instrument = _instrumentService.GetById(id);
			MusicInstrumentDTO instrumentDto = _mapper.Map<MusicInstrumentDTO>(instrument);
			return Ok(instrumentDto);
		}


		/// <summary>
		/// Add instrument
		/// </summary>
		[HttpPost]
		public IActionResult AddInstrument(MusicInstrument instrument)
		{
			_instrumentService.Add(instrument);
			return Ok("Instrument added");
		}

		/// <summary>
		/// Remove instrument
		/// </summary>
		[HttpDelete]
		public IActionResult RemoveInstrument(MusicInstrument instrument)
		{

			_instrumentService.Remove(instrument);
			return Ok("Instrument removed");
		}

		/// <summary>
		/// Update instrument
		/// </summary>
		[HttpPut]
		public IActionResult UpdateSong(MusicInstrument instrument)
		{

			_instrumentService.Update(instrument);
			return Ok("Instrument updated");
		}
	}
}


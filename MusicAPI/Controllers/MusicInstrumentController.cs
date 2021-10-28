using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using ModelsDto;
using System.Collections.Generic;
using System.Threading.Tasks;

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
		public async Task<IActionResult> GetAllInstruments()
		{
			var instruments = await _instrumentService.GetAll();
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
		public async Task<IActionResult> GetInstrumentById(int id)
		{
			var instrument = await _instrumentService.GetById(id);
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
		public async Task<IActionResult> AddInstrument(MusicInstrumentDto instrumentDto)
		{
			MusicInstrument instrument = _mapper.Map<MusicInstrument>(instrumentDto);
			await _instrumentService.Add(instrument);
			return Ok("Instrument added");
		}

		/// <summary>
		/// Remove instrument
		/// </summary>
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveInstrument(int id)
		{

			await _instrumentService.RemoveById(id);
			return Ok("Instrument removed");
		}

		/// <summary>
		/// Update instrument
		/// </summary>
		[HttpPut]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UpdateSong(MusicInstrumentDto instrumentDto)
		{
			MusicInstrument instrument = _mapper.Map<MusicInstrument>(instrumentDto);
			await _instrumentService.Update(instrument);
			return Ok("Instrument updated");
		}
	}
}


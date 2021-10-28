using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsDto;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MusicalController : ControllerBase
	{
		private readonly IMusicianService _musicianService;
		private readonly IMapper _mapper;

		public MusicalController(IMapper mapper, IMusicianService musicianService)
		{
			_mapper = mapper;
			_musicianService = musicianService;
		}

		/// <summary>
		/// Get all musicians
		/// </summary>
		/// <returns>List musicians</returns>
		[HttpGet]
		public async Task<IActionResult> GetAllMusicians()
		{
			var musicians = await _musicianService.GetAll();
			if (musicians == null)
			{
				return NotFound();
			}
			IEnumerable<MusicianDto> musiciansDto = _mapper.Map<IEnumerable<MusicianDto>>(musicians);
			return Ok(musiciansDto);
		}

		/// <summary>
		/// Get musician by id
		/// </summary>
		/// <returns>Musician</returns>
		[HttpGet("{id}")]
		public IActionResult GetMusicianById(int id)
		{
			var musician = _musicianService.GetByIdWithInclude(id);
			if (musician == null)
			{
				return NotFound();
			}
			MusicianDto musicianDto = _mapper.Map<MusicianDto>(musician);
			return Ok(musicianDto);
			
		}


		/// <summary>
		/// Add musician
		/// </summary>
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddMusican(MusicianDto musicianDto)
		{
			Musician musician = _mapper.Map<Musician>(musicianDto);
			await _musicianService.Add(musician);
			return Ok("Musican added");
		}

		/// <summary>
		/// Add music instrument to musician
		/// </summary>
		[HttpPost]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddMusicInstrument(int id, MusicInstrumentDto instrumentDTO)
		{

			MusicInstrument instrument = _mapper.Map<MusicInstrument>(instrumentDTO);
			await _musicianService.AddInstrumentToMusician(id, instrument);

			return Ok("Music instrument added");
		}

		/// <summary>
		/// Add genre to musician
		/// </summary>
		[HttpPost]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddGenre(int id, GenreDto genreDTO)
		{
			Genre genre = _mapper.Map<Genre>(genreDTO);
			await _musicianService.AddGenreToMusician(id, genre);

			return Ok("Genre added");
		}

		/// <summary>
		/// Remove musician by id
		/// </summary>
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveMusician(int id)
		{
			await _musicianService.RemoveById(id);
			return Ok("Musican removed");
		}

		/// <summary>
		/// Remove music instrument
		/// </summary>
		[HttpDelete]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveMusicInstrument(int musicianId, int instrumentId)
		{
			await _musicianService.RemoveInstrumentToMusician(musicianId, instrumentId);
			return Ok("Music instrument removed");
		}

		/// <summary>
		/// Remove genre
		/// </summary>
		[HttpDelete]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveGenre(int musicianId, int genreId)
		{
			await _musicianService.RemoveGenreToMusician(musicianId, genreId);
			return Ok("Genre removed");
		}

		/// <summary>
		/// Update musician
		/// </summary>
		[HttpPut]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UpdateMusician(MusicianDto musicianDto)
		{
			Musician musician = _mapper.Map<Musician>(musicianDto);
			await _musicianService.Update(musician);
			return Ok("Musican updated");
		}


	}
}

using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelsDto.MusicDto;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
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
		public async Task<IActionResult> GetMusicianById(int id)
		{
			var musician = await _musicianService.GetByIdWithInclude(id);
			if (musician == null)
			{
				return NotFound();
			}
			MusicianDetailsDto musicianDto = _mapper.Map<MusicianDetailsDto>(musician);
			return Ok(musicianDto);

		}

		/// <summary>
		/// Add musician
		/// </summary>
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddMusican(MusicianDetailsDto musicianDto)
		{
			Musician musician = _mapper.Map<Musician>(musicianDto);
			await _musicianService.Add(musician);
			return Ok();
		}
		/// <summary>
		/// Update musician
		/// </summary>
		[HttpPut]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UpdateMusician(MusicianDetailsDto musicianDto)
		{
			if (musicianDto.Id == 0)
			{
				return BadRequest();
			}
			Musician musician = _mapper.Map<Musician>(musicianDto);
			await _musicianService.Update(musician);
			return Ok();
		}

		/// <summary>
		/// Remove musician by id
		/// </summary>
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveMusician(int id)
		{
			await _musicianService.RemoveById(id);
			return Ok();
		}

	}
}

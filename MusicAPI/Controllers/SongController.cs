using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using ModelsDto.MusicDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SongController : ControllerBase
	{
		private readonly ISongService _songService;
		private readonly IMapper _mapper;

		public SongController(ISongService songService, IMapper mapper)
		{
			_songService = songService;
			_mapper = mapper;
		}

		/// <summary>
		/// Get all songs
		/// </summary>
		/// <returns>List songs</returns>
		[HttpGet]
		public async Task<IActionResult> GetAllSongs()
		{
			var songs = await _songService.GetAll();
			if (songs == null)
			{
				return NotFound();
			}
			IEnumerable<SongDto> songsDto = _mapper.Map<IEnumerable<SongDto>>(songs);
			return Ok(songsDto);
		}

		/// <summary>
		/// Get song by id
		/// </summary>
		/// <returns>Song</returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetSongById(int id)
		{
			var song = await _songService.GetByIdWithInclude(id);
			if (song == null)
			{
				return NotFound();
			}
			SongDetailsDto songDto = _mapper.Map<SongDetailsDto>(song);
			return Ok(songDto);
		}


		/// <summary>
		/// Add song
		/// </summary>
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddSong(SongDetailsDto songDto)
		{
			Song song = _mapper.Map<Song>(songDto);
			await _songService.Add(song);
			return Ok();
		}

		/// <summary>
		/// Remove song
		/// </summary>
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveSong(int id)
		{
			await _songService.RemoveById(id);
			return Ok();
		}

		/// <summary>
		/// Update song
		/// </summary>
		[HttpPut]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UpdateSong(SongDetailsDto songDto)
		{
			Song song = _mapper.Map<Song>(songDto);
			await _songService.Update(song);
			return Ok();
		}
	}
}

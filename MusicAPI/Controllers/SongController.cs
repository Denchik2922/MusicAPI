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
		public IActionResult GetAllSongs()
		{
			var songs = _songService.GetAll();
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
		public IActionResult GetSongById(int id)
		{
			var song = _songService.GetByIdWithInclude(id);
			if (song == null)
			{
				return NotFound();
			}
			SongDto songDto = _mapper.Map<SongDto>(song);
			return Ok(songDto);
		}


		/// <summary>
		/// Add song
		/// </summary>
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public IActionResult AddSong(SongDto songDto)
		{
			Song song = _mapper.Map<Song>(songDto);
			_songService.Add(song);
			return Ok("Song added");
		}

		/// <summary>
		/// Remove song
		/// </summary>
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public IActionResult RemoveSong(int id)
		{
			_songService.RemoveById(id);
			return Ok("Song removed");
		}

		/// <summary>
		/// Update song
		/// </summary>
		[HttpPut]
		[Authorize(Roles = "Admin")]
		public IActionResult UpdateSong(SongDto songDto)
		{
			Song song = _mapper.Map<Song>(songDto);
			_songService.Update(song);
			return Ok("Song updated");
		}
	}
}

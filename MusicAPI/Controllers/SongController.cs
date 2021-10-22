using AutoMapper;
using BLL.Interfaces;
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
			return Ok(_songService.GetAll());
		}

		/// <summary>
		/// Get song by id
		/// </summary>
		/// <returns>Song</returns>
		[HttpGet("{id}")]
		public IActionResult GetSongById(int id)
		{
			var song = _songService.GetByIdWithInclude(id);
			SongDto songDto = _mapper.Map<SongDto>(song);
			return Ok(songDto);
		}


		/// <summary>
		/// Add song
		/// </summary>
		[HttpPost]
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
		public IActionResult RemoveSong(int id)
		{
			_songService.RemoveById(id);
			return Ok("Song removed");
		}

		/// <summary>
		/// Update song
		/// </summary>
		[HttpPut]
		public IActionResult UpdateSong(SongDto songDto)
		{
			Song song = _mapper.Map<Song>(songDto);
			_songService.Update(song);
			return Ok("Song updated");
		}
	}
}

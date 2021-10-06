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
	public class SongController : ControllerBase
	{
		private readonly IGenericService<Song> _songService;
		private readonly IMapper _mapper;

		public SongController(IGenericService<Song> songService, IMapper mapper)
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
			var song = _songService.GetWithInclude(x => x.Id == id, s => s.Genres,
														s => s.MusicAlbum);
			List<SongDTO> songDto = _mapper.Map<List<SongDTO>>(song);
			return Ok(songDto);
		}


		/// <summary>
		/// Add song
		/// </summary>
		[HttpPost]
		public IActionResult AddSong(Song song)
		{
			_songService.Add(song);
			return Ok("Song added");
		}

		/// <summary>
		/// Remove song
		/// </summary>
		[HttpDelete]
		public IActionResult RemoveSong(Song song)
		{

			_songService.Remove(song);
			return Ok("Song removed");
		}

		/// <summary>
		/// Update song
		/// </summary>
		[HttpPut]
		public IActionResult UpdateSong(Song song)
		{

			_songService.Update(song);
			return Ok("Song updated");
		}
	}
}

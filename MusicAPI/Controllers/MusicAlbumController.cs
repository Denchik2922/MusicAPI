using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using MusicAPI.ModelsDto;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MusicAlbumController : ControllerBase
	{
		private readonly IMusicAlbumService _albumService;
		private readonly IMapper _mapper;

		public MusicAlbumController(IMusicAlbumService albumService, IMapper mapper)
		{
			_albumService = albumService;
			_mapper = mapper;
		}

		/// <summary>
		/// Get all music album
		/// </summary>
		/// <returns>List music albums</returns>
		[HttpGet]
		public IActionResult GetAllMusicAlbum()
		{
			var albums = _albumService.GetAll();
			if (albums == null)
			{
				return NotFound();
			}
			IEnumerable<MusicAlbumDto> albumsDto = _mapper.Map<IEnumerable<MusicAlbumDto>>(albums);
			return Ok(albumsDto);
		}

		/// <summary>
		/// Get music album by id
		/// </summary>
		/// <returns>Music Album</returns>
		[HttpGet("{id}")]
		public IActionResult GetMusicAlbumById(int id)
		{
			var musicAlbum = _albumService.GetByIdWithInclude(id);
			if (musicAlbum == null)
			{
				return NotFound();
			}
			MusicAlbumDto musicAlbumDto = _mapper.Map<MusicAlbumDto>(musicAlbum);
			return Ok(musicAlbumDto);
		}

		/// <summary>
		/// Add music album
		/// </summary>
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public IActionResult AddMusicAlbum(MusicAlbumDto musicAlbumDto)
		{
			MusicAlbum musicAlbum = _mapper.Map<MusicAlbum>(musicAlbumDto);
			_albumService.Add(musicAlbum);
			return Ok("Music album added");
		}

		/// <summary>
		/// Add song to album
		/// </summary>
		[HttpPost]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public IActionResult AddSong(int albumId, SongDto songDto)
		{
			Song song = _mapper.Map<Song>(songDto);
			_albumService.AddSongToAlbum(albumId, song);
			return Ok("Song added");
		}

		/// <summary>
		/// Add genre to album
		/// </summary>
		[HttpPost]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public IActionResult AddGenre(int albumId, GenreDto genreDTO)
		{
			Genre genre = _mapper.Map<Genre>(genreDTO);
			_albumService.AddGenreToAlbum(albumId, genre);
			return Ok("Genre added");
		}

		/// <summary>
		/// Remove music album by id
		/// </summary>
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public IActionResult RemoveMusicAlbum(int id)
		{
			_albumService.RemoveById(id);
			return Ok("Music album removed");
		}

		/// <summary>
		/// Remove song
		/// </summary>
		[HttpDelete]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public IActionResult RemoveSong(int albumId, int songId)
		{
			_albumService.RemoveSongToAlbum(albumId, songId);
			return Ok("Song removed");
		}

		/// <summary>
		/// Remove genre
		/// </summary>
		[HttpDelete]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public IActionResult RemoveGenre(int albumId, int genreId)
		{
			_albumService.RemoveGenreToAlbum(albumId, genreId);
			return Ok("Genre removed");
		}

		/// <summary>
		/// Update music album
		/// </summary>
		[HttpPut]
		[Authorize(Roles = "Admin")]
		public IActionResult UpdateMusicAlbum(MusicAlbumDto musicAlbumDto)
		{
			MusicAlbum musicAlbum = _mapper.Map<MusicAlbum>(musicAlbumDto);
			_albumService.Update(musicAlbum);
			return Ok("Music album updated");
		}
	}
}

using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ModelsDTO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MusicAlbumController : ControllerBase
	{
		private readonly IGenericService<MusicAlbum> _albumService;
		private readonly IMapper _mapper;

		public MusicAlbumController(IGenericService<MusicAlbum> albumService, IMapper mapper)
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
			return Ok(_albumService.GetAll());
		}

		/// <summary>
		/// Get music album by id
		/// </summary>
		/// <returns>Music Album</returns>
		[HttpGet("{id}")]
		public IActionResult GetMusicAlbumById(int id)
		{
			var musicAlbum = _albumService.GetWithInclude(x => x.Id == id, a => a.Genres,
														a => a.Songs);
			List<MusicAlbumDTO> musicAlbumDto = _mapper.Map<List<MusicAlbumDTO>>(musicAlbum);
			return Ok(musicAlbum);
		}


		/// <summary>
		/// Add music album
		/// </summary>
		[HttpPost]
		public IActionResult AddMusicAlbum(MusicAlbum musicAlbum)
		{
			_albumService.Add(musicAlbum);
			return Ok("Music album added");
		}

		/// <summary>
		/// Remove music album
		/// </summary>
		[HttpDelete]
		public IActionResult RemoveMusicAlbum(MusicAlbum musicAlbum)
		{

			_albumService.Remove(musicAlbum);
			return Ok("Music album removed");
		}

		/// <summary>
		/// Update music album
		/// </summary>
		[HttpPut]
		public IActionResult UpdateMusicAlbum(MusicAlbum musicAlbum)
		{

			_albumService.Update(musicAlbum);
			return Ok("Music album updated");
		}
	}
}

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
		public async Task<IActionResult> GetAllMusicAlbum()
		{
			var albums = await _albumService.GetAll();
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
		public async Task<IActionResult> GetMusicAlbumById(int id)
		{
			var musicAlbum = await _albumService.GetByIdWithInclude(id);
			if (musicAlbum == null)
			{
				return NotFound();
			}
			AlbumDetailsDto musicAlbumDto = _mapper.Map<AlbumDetailsDto>(musicAlbum);
			return Ok(musicAlbumDto);
		}

		/// <summary>
		/// Add music album
		/// </summary>
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddMusicAlbum(AlbumDetailsDto musicAlbumDto)
		{
			MusicAlbum musicAlbum = _mapper.Map<MusicAlbum>(musicAlbumDto);
			await _albumService.Add(musicAlbum);
			return Ok();
		}

		/// <summary>
		/// Remove music album by id
		/// </summary>
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveMusicAlbum(int id)
		{
			await _albumService.RemoveById(id);
			return Ok();
		}

		/// <summary>
		/// Update music album
		/// </summary>
		[HttpPut]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UpdateMusicAlbum(AlbumDetailsDto musicAlbumDto)
		{
			MusicAlbum musicAlbum = _mapper.Map<MusicAlbum>(musicAlbumDto);
			await _albumService.Update(musicAlbum);
			return Ok();
		}
	}
}

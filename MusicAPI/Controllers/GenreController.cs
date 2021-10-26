using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using MusicAPI.ModelsDto;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : ControllerBase
	{
		private readonly IGenericService<Genre> _genreService;
		private readonly IMapper _mapper;

		public GenreController(IGenericService<Genre> genreService, IMapper mapper)
		{
			_genreService = genreService;
			_mapper = mapper;
		}

		/// <summary>
		/// Get all genres
		/// </summary>
		/// <returns>List genres</returns>
		[HttpGet]
		public async Task<IActionResult> GetAllGenres()
		{
			var genres = await _genreService.GetAll();
			if (genres == null)
			{
				return NotFound();
			}
			IEnumerable<GenreDto> genresDto = _mapper.Map<IEnumerable<GenreDto>>(genres);
			return Ok(genresDto);
		}

		/// <summary>
		/// Get group by id
		/// </summary>
		/// <returns>Group</returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetGenreById(int id)
		{
			var genre = await _genreService.GetById(id);
			if (genre == null)
			{
				return NotFound();
			}
			GenreDto genreDto = _mapper.Map<GenreDto>(genre);
			return Ok(genreDto);
		}


		/// <summary>
		/// Add genre
		/// </summary>
		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> AddGenre(GenreDto genreDto)
		{
			Genre genre = _mapper.Map<Genre>(genreDto);
			await _genreService.Add(genre);
			return Ok("Genre added");
		}

		/// <summary>
		/// Remove genre
		/// </summary>
		[Authorize(Roles = "Admin")]
		[HttpDelete]
		public async Task<IActionResult> RemoveGenre(int id)
		{
			await _genreService.RemoveById(id);
			return Ok("Genre removed");
		}

		/// <summary>
		/// Update genre
		/// </summary>
		[Authorize(Roles = "Admin")]
		[HttpPut]
		public async Task<IActionResult> UpdateGenre(GenreDto genreDto)
		{
			Genre genre = _mapper.Map<Genre>(genreDto);
			await _genreService.Update(genre);
			return Ok("Genre updated");
		}
	}
}

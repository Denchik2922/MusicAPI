using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using MusicAPI.ModelsDto;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
		public IActionResult GetAllGenres()
		{
			return Ok(_genreService.GetAll());
		}

		/// <summary>
		/// Get group by id
		/// </summary>
		/// <returns>Group</returns>
		[HttpGet("{id}")]
		public IActionResult GetGenreById(int id)
		{
			var genre = _genreService.GetById(id);
			GenreDto genreDto = _mapper.Map<GenreDto>(genre);
			return Ok(genreDto);
		}


		/// <summary>
		/// Add genre
		/// </summary>
		[HttpPost]
		public IActionResult AddGenre(GenreDto genreDto)
		{
			Genre genre = _mapper.Map<Genre>(genreDto);
			_genreService.Add(genre);
			return Ok("Genre added");
		}

		/// <summary>
		/// Remove genre
		/// </summary>
		[HttpDelete]
		public IActionResult RemoveGenre(int id)
		{
			_genreService.RemoveById(id);
			return Ok("Genre removed");
		}

		/// <summary>
		/// Update genre
		/// </summary>
		[HttpPut]
		public IActionResult UpdateGenre(GenreDto genreDto)
		{
			Genre genre = _mapper.Map<Genre>(genreDto);
			_genreService.Update(genre);
			return Ok("Genre updated");
		}
	}
}

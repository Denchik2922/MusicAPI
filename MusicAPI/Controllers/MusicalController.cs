﻿using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.ModelsDTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

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
		public IActionResult GetAllMusicians()
		{
			return Ok(_musicianService.GetAll());
		}

		/// <summary>
		/// Get musician by id
		/// </summary>
		/// <returns>Musician</returns>
		[HttpGet("{id}")]
		public IActionResult GetMusicianById(int id)
		{
			
			var musician = _musicianService.GetByIdWithInclude(id);
			MusicianDTO musicianDto = _mapper.Map<MusicianDTO>(musician);
			return Ok(musicianDto);
		}


		/// <summary>
		/// Add musician
		/// </summary>
		[HttpPost]
		public IActionResult AddMusican(MusicianDTO musicianDto)
		{
			Musician musician = _mapper.Map<Musician>(musicianDto);
			_musicianService.Add(musician);
			return Ok("Musican added");
		}

		/// <summary>
		/// Add music instrument to musician
		/// </summary>
		[HttpPost]
		[Route("[action]")]
		public IActionResult AddMusicInstrument(int id, MusicInstrumentDTO instrumentDTO)
		{

			MusicInstrument instrument = _mapper.Map<MusicInstrument>(instrumentDTO);
			_musicianService.AddInstrumentToMusician(id, instrument);

			return Ok("Music instrument added");
		}

		/// <summary>
		/// Add genre to musician
		/// </summary>
		[HttpPost]
		[Route("[action]")]
		public IActionResult AddGenre(int id, GenreDTO genreDTO)
		{
			Genre genre = _mapper.Map<Genre>(genreDTO);
			_musicianService.AddGenreToMusician(id, genre);

			return Ok("Genre added");
		}

		/// <summary>
		/// Remove musician by id
		/// </summary>
		[HttpDelete]
		public IActionResult RemoveMusician(int id)
		{
			_musicianService.RemoveById(id);
			return Ok("Musican removed");
		}

		/// <summary>
		/// Remove music instrument
		/// </summary>
		[HttpDelete]
		[Route("[action]")]
		public IActionResult RemoveMusicInstrument(int musicianId, int instrumentId)
		{
			_musicianService.RemoveInstrumentToMusician(musicianId, instrumentId);
			return Ok("Music instrument removed");
		}

		/// <summary>
		/// Remove genre
		/// </summary>
		[HttpDelete]
		[Route("[action]")]
		public IActionResult RemoveGenre(int musicianId, int genreId)
		{
			_musicianService.RemoveGenreToMusician(musicianId, genreId);
			return Ok("Genre removed");
		}

		/// <summary>
		/// Update musician
		/// </summary>
		[HttpPut]
		public IActionResult UpdateMusician(MusicianDTO musicianDto)
		{
			Musician musician = _mapper.Map<Musician>(musicianDto);
			_musicianService.Update(musician);
			return Ok("Musican updated");
		}


	}
}

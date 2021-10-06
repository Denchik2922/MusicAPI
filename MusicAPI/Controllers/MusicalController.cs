using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.ModelsDTO;
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
		private readonly IGenericService<Musician> _musicService;
		private readonly IMapper _mapper;

		public MusicalController(IGenericService<Musician> musicService, IMapper mapper)
		{
			_musicService = musicService;
			_mapper = mapper;
		}

		/// <summary>
		/// Get all musicians
		/// </summary>
		/// <returns>List musicians</returns>
		[HttpGet]
		public IActionResult GetAllMusicians()
		{
			return Ok(_musicService.GetAll());
		}

		/// <summary>
		/// Get musican by id
		/// </summary>
		/// <returns>Musican</returns>
		[HttpGet("{id}")]
		public IActionResult GetMusicanById(int id)
		{
			var musician = _musicService.GetWithInclude(x => x.Id == id, m => m.Group,
														m => m.MusicInstruments,
														m => m.Genres);
			List<MusicianDTO> musicianDto = _mapper.Map<List<MusicianDTO>>(musician);
			return Ok(musicianDto);
		}


		/// <summary>
		/// Add musican
		/// </summary>
		[HttpPost]
		public IActionResult AddMusican(Musician musician)
		{
			_musicService.Add(musician);
			return Ok("Musican added");
		}

		/// <summary>
		/// Remove musican
		/// </summary>
		[HttpDelete]
		public IActionResult RemoveMusican(Musician musician)
		{

			_musicService.Remove(musician);
			return Ok("Musican removed");
		}

		/// <summary>
		/// Update musican
		/// </summary>
		[HttpPut]
		public IActionResult UpdateMusican(Musician musician)
		{

			_musicService.Update(musician);
			return Ok("Musican updated");
		}


	}
}

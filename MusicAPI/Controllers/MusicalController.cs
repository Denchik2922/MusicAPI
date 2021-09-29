using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MusicalController : ControllerBase
	{
		private readonly IMusicalService _db;

		public MusicalController(IMusicalService db)
		{
			_db = db;
		}

		/// <summary>
		/// Get all musicians
		/// </summary>
		/// <returns>List musicians</returns>
		[HttpGet]
		public IActionResult GetAllMusicians()
		{
			return Ok(_db.GetAllMusicians());
		}



	}
}

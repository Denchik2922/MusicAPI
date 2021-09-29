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
	public class GroupController : ControllerBase
	{
		private readonly IGroupService _db;

		public GroupController(IGroupService db)
		{
			_db = db;
		}

		/// <summary>
		/// Get all groups
		/// </summary>
		/// <returns>List groups</returns>
		[HttpGet]
		public IActionResult GetAllGroups()
		{
			return Ok(_db.GetAllGroup());
		}

	}
}

using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
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
		private readonly IGenericService<Group> _groupService;

		public GroupController(IGenericService<Group> groupService)
		{
			_groupService = groupService;
		}

		/// <summary>
		/// Get all groups
		/// </summary>
		/// <returns>List groups</returns>
		[HttpGet]
		public IActionResult GetAllGroups()
		{
			return Ok(_groupService.GetAll());
		}

	}
}

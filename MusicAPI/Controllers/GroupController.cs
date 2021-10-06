using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ModelsDTO;
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
		private readonly IMapper _mapper;

		public GroupController(IGenericService<Group> groupService, IMapper mapper)
		{
			_groupService = groupService;
			_mapper = mapper;
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

		/// <summary>
		/// Get group by id
		/// </summary>
		/// <returns>Group</returns>
		[HttpGet("{id}")]
		public IActionResult GetGroupById(int id)
		{
			var group = _groupService.GetWithInclude(x => x.Id == id, g => g.Genres,
														g => g.Members);
			List<GroupDTO> groupDto = _mapper.Map<List<GroupDTO>>(group);
			return Ok(groupDto);
		}


		/// <summary>
		/// Add group
		/// </summary>
		[HttpPost]
		public IActionResult AddGroup(Group group)
		{
			_groupService.Add(group);
			return Ok("Group added");
		}

		/// <summary>
		/// Remove group
		/// </summary>
		[HttpDelete]
		public IActionResult RemoveGroup(Group group)
		{

			_groupService.Remove(group);
			return Ok("Group removed");
		}

		/// <summary>
		/// Update group
		/// </summary>
		[HttpPut]
		public IActionResult UpdateGroup(Group group)
		{

			_groupService.Update(group);
			return Ok("Group updated");
		}
	}
}

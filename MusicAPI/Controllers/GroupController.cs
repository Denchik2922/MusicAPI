using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using ModelsDto;
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
		private readonly IGroupService _groupService;
		private readonly IMapper _mapper;

		public GroupController(IGroupService groupService, IMapper mapper)
		{
			_groupService = groupService;
			_mapper = mapper;
		}

		/// <summary>
		/// Get all groups
		/// </summary>
		/// <returns>List groups</returns>
		[HttpGet]
		public async Task<IActionResult> GetAllGroups()
		{
			var groups = await _groupService.GetAll();
			if (groups == null)
			{
				return NotFound();
			}
			IEnumerable<GroupDto> groupsDto = _mapper.Map<IEnumerable<GroupDto>>(groups);
			return Ok(groupsDto);
		}

		/// <summary>
		/// Get group by id
		/// </summary>
		/// <returns>Group</returns>
		[HttpGet("{id}")]
		public IActionResult GetGroupById(int id)
		{
			var group = _groupService.GetByIdWithInclude(id);
			if (group == null)
			{
				return NotFound();
			}
			GroupDto groupDto = _mapper.Map<GroupDto>(group);
			return Ok(groupDto);
		}

		/// <summary>
		/// Add group
		/// </summary>
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddGroup(GroupDto groupDto)
		{
			Group group = _mapper.Map<Group>(groupDto);
			await _groupService.Add(group);
			return Ok("Group added");
		}

		/// <summary>
		/// Add member to group
		/// </summary>
		[HttpPost]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddMemberToGroup(int groupId, MusicianDto musicianDto)
		{
			Musician musician = _mapper.Map<Musician>(musicianDto);
			await _groupService.AddMemberToGroup(groupId, musician);
			return Ok("Member added");
		}

		/// <summary>
		/// Add genre to group
		/// </summary>
		[HttpPost]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddGenreToGroup(int groupId, GenreDto genreDTO)
		{
			Genre genre = _mapper.Map<Genre>(genreDTO);
			await _groupService.AddGenreToGroup(groupId, genre);
			return Ok("Genre added");
		}

		/// <summary>
		/// Remove group
		/// </summary>
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveGroup(int id)
		{

			await _groupService.RemoveById(id);
			return Ok("Group removed");
		}

		/// <summary>
		/// Remove member
		/// </summary>
		[HttpDelete]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveMember(int groupId, int memberId)
		{
			await _groupService.RemoveMemberToGroup(groupId, memberId);
			return Ok("Member removed");
		}

		/// <summary>
		/// Remove genre
		/// </summary>
		[HttpDelete]
		[Route("[action]")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveGenre(int groupId, int genreId)
		{
			await _groupService.RemoveGenreToGroup(groupId, genreId);
			return Ok("Genre removed");
		}

		/// <summary>
		/// Update group
		/// </summary>
		[HttpPut]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UpdateGroup(GroupDto groupDto)
		{
			Group group = _mapper.Map<Group>(groupDto);
			await _groupService.Update(group);
			return Ok("Group updated");
		}
	}
}

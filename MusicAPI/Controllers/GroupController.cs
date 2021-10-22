using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using MusicAPI.ModelsDto;
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
			var group = _groupService.GetByIdWithInclude(id);
			GroupDto groupDto = _mapper.Map<GroupDto>(group);
			return Ok(groupDto);
		}

		/// <summary>
		/// Add group
		/// </summary>
		[HttpPost]
		public IActionResult AddGroup(GroupDto groupDto)
		{
			Group group = _mapper.Map<Group>(groupDto);
			_groupService.Add(group);
			return Ok("Group added");
		}

		/// <summary>
		/// Add member to group
		/// </summary>
		[HttpPost]
		[Route("[action]")]
		public IActionResult AddMemberToGroup(int groupId, MusicianDto musicianDto)
		{
			Musician musician = _mapper.Map<Musician>(musicianDto);
			_groupService.AddMemberToGroup(groupId, musician);
			return Ok("Member added");
		}

		/// <summary>
		/// Add genre to group
		/// </summary>
		[HttpPost]
		[Route("[action]")]
		public IActionResult AddGenreToGroup(int groupId, GenreDto genreDTO)
		{
			Genre genre = _mapper.Map<Genre>(genreDTO);
			_groupService.AddGenreToGroup(groupId, genre);
			return Ok("Genre added");
		}

		/// <summary>
		/// Remove group
		/// </summary>
		[HttpDelete]
		public IActionResult RemoveGroup(int id)
		{

			_groupService.RemoveById(id);
			return Ok("Group removed");
		}

		/// <summary>
		/// Remove member
		/// </summary>
		[HttpDelete]
		[Route("[action]")]
		public IActionResult RemoveMember(int groupId, int memberId)
		{
			_groupService.RemoveMemberToGroup(groupId, memberId);
			return Ok("Member removed");
		}

		/// <summary>
		/// Remove genre
		/// </summary>
		[HttpDelete]
		[Route("[action]")]
		public IActionResult RemoveGenre(int groupId, int genreId)
		{
			_groupService.RemoveGenreToGroup(groupId, genreId);
			return Ok("Genre removed");
		}

		/// <summary>
		/// Update group
		/// </summary>
		[HttpPut]
		public IActionResult UpdateGroup(GroupDto groupDto)
		{
			Group group = _mapper.Map<Group>(groupDto);
			_groupService.Update(group);
			return Ok("Group updated");
		}
	}
}

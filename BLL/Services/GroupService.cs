﻿using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class GroupService : BaseGenericService<Group>, IGroupService
	{
		public GroupService(MusicContext context, ILogger<GroupService> logger) : base(context, logger) { }

		public Group GetByIdWithInclude(int id)
		{
			var groups = _context.Groups
				.Where(g => g.Id == id);
			if (groups.Count() < 1)
			{
				string ErrorMsg = $"Group with id - {id} not found";
				_logger.LogWarning(ErrorMsg);
				throw new Exception(ErrorMsg);
			}

			return groups
				.Include(g => g.Genres)
				.Include(g => g.Members)
				.FirstOrDefault();
		}

		public async Task AddMemberToGroup(int groupId, Musician musician)
		{
			Group group = GetByIdWithInclude(groupId);

			try
			{
				group.Members.Add(musician);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				string ErrorMsg = $"Error adding member - {musician.FirstName} to group with id - {groupId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
			
		}

		public async Task RemoveMemberToGroup(int groupId, int memberId)
		{
			Group group = GetByIdWithInclude(groupId);

			try
			{
				group.Members.RemoveAll(i => i.Id == memberId);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				string ErrorMsg = $"Error removing memberId - {memberId} to group with id - {groupId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
			
		}

		public async Task AddGenreToGroup(int groupId, Genre genre)
		{
			Group group = GetByIdWithInclude(groupId);

			try
			{
				group.Genres.Add(genre);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{

				string ErrorMsg = $"Error adding genre - {genre.Name} to group with id - {groupId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
		}

		public async Task RemoveGenreToGroup(int groupId, int genreId)
		{
			Group group = GetByIdWithInclude(groupId);

			try
			{
				group.Genres.RemoveAll(i => i.Id == genreId);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				string ErrorMsg = $"Error removing genreId - {genreId} to group with id - {groupId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
			
			
		}


	}
}

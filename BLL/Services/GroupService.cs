using BLL.Interfaces;
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
		public GroupService(MusicContext context) : base(context) { }

		public Group GetByIdWithInclude(int id)
		{
			var groups = _context.Groups
				.Where(g => g.Id == id);
			if (groups.Count() < 1)
			{
				throw new ArgumentNullException($"Group with id - {id} not found");
			}

			return groups
				.Include(g => g.Genres)
				.Include(g => g.Members)
				.FirstOrDefault();
		}

		public async Task AddMemberToGroup(int groupId, Musician musician)
		{
			Group group = GetByIdWithInclude(groupId);
			group.Members.Add(musician);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveMemberToGroup(int groupId, int memberId)
		{
			Group group = GetByIdWithInclude(groupId);
			group.Members.RemoveAll(i => i.Id == memberId);
			await _context.SaveChangesAsync();
		}

		public async Task AddGenreToGroup(int groupId, Genre genre)
		{
			Group group = GetByIdWithInclude(groupId);
			group.Genres.Add(genre);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveGenreToGroup(int groupId, int genreId)
		{
			Group group = GetByIdWithInclude(groupId);
			group.Genres.RemoveAll(i => i.Id == genreId);
			await _context.SaveChangesAsync();
		}
	}
}

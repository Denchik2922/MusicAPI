using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace BLL.Services
{
	public class GroupService : BaseGenericService<Group>, IGroupService
	{
		public GroupService(MusicContext context) : base(context) { }

		public Group GetByIdWithInclude(int id)
		{
			return _context.Groups
				.Where(g => g.Id == id)
				.Include(g => g.Genres)
				.Include(g => g.Members)
				.FirstOrDefault();
		}

		public void AddMemberToGroup(int groupId, Musician musician)
		{
			Group group = GetByIdWithInclude(groupId);
			group.Members.Add(musician);
			_context.SaveChanges();
		}

		public void RemoveMemberToGroup(int groupId, int memberId)
		{
			Group group = GetByIdWithInclude(groupId);
			group.Members.RemoveAll(i => i.Id == memberId);
			_context.SaveChanges();
		}

		public void AddGenreToGroup(int groupId, Genre genre)
		{
			Group group = GetByIdWithInclude(groupId);
			group.Genres.Add(genre);
			_context.SaveChanges();
		}

		public void RemoveGenreToGroup(int groupId, int genreId)
		{
			Group group = GetByIdWithInclude(groupId);
			group.Genres.RemoveAll(i => i.Id == genreId);
			_context.SaveChanges();
		}


	}
}

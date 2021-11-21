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
		private IDbHelperService _dbHelper;
		public GroupService(MusicContext context, IDbHelperService dbHelper) : base(context)
		{
			_dbHelper = dbHelper;
		}

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
				.Include(g => g.MusicAlbums)
				.FirstOrDefault();
		}

		public async override Task Add(Group entity)
		{
			_context.Genres.AttachRange(entity.Genres);
			_context.Musicians.AttachRange(entity.Members);
			_context.MusicAlbums.AttachRange(entity.MusicAlbums);
			await _context.Groups.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public override async Task Update(Group entity)
		{
			Group group = GetByIdWithInclude(entity.Id);
			group.Name = entity.Name;
			group.Country = entity.Country;

			var members = _context.Musicians.ToList()
										.Where(i => entity.Members
														  .Exists(el => el.Id == i.Id)).ToList();

			_dbHelper.AddItemsToRelationLists(group.Members, members);
			_dbHelper.RemoveItemsFromRelationLists(group.Members, entity.Members);


			var genres = _context.Genres.ToList()
										.Where(g => entity.Genres
														  .Exists(el => el.Id == g.Id)).ToList();

			_dbHelper.AddItemsToRelationLists(group.Genres, genres);
			_dbHelper.RemoveItemsFromRelationLists(group.Genres, entity.Genres);


			var albums = _context.MusicAlbums.ToList()
										.Where(g => entity.MusicAlbums
														  .Exists(el => el.Id == g.Id)).ToList();

			_dbHelper.AddItemsToRelationLists(group.MusicAlbums, albums);
			_dbHelper.RemoveItemsFromRelationLists(group.MusicAlbums, entity.MusicAlbums);

			await _context.SaveChangesAsync();
		}

	}
}

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
	public class MusicAlbumService : BaseGenericService<MusicAlbum>, IMusicAlbumService
	{
		private IDbHelperService _dbHelper;

		public MusicAlbumService(MusicContext context, IDbHelperService dbHelper) : base(context) {
			_dbHelper = dbHelper;

		}

		public MusicAlbum GetByIdWithInclude(int id)
		{
			var musicAlbums = _context.MusicAlbums
				.Where(m => m.Id == id);
			if (musicAlbums.Count() < 1)
			{
				throw new ArgumentNullException($"Music Album with id - {id} not found");
			}

			return musicAlbums
				.Include(m => m.Genres)
				.Include(m => m.Songs)
				.FirstOrDefault();
		}

		public async override Task Add(MusicAlbum entity)
		{
			_context.Genres.AttachRange(entity.Genres);
			_context.Songs.AttachRange(entity.Songs);

			await _context.MusicAlbums.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public override async Task Update(MusicAlbum entity)
		{
			MusicAlbum album = GetByIdWithInclude(entity.Id);
			album.Name = entity.Name;
			album.Released = entity.Released;
			album.Length = entity.Length;

			album.GroupId = entity.GroupId;

			var songs = _context.Songs.ToList()
										.Where(i => entity.Songs
														  .Exists(el => el.Id == i.Id)).ToList();

			_dbHelper.AddItemsToRelationLists(album.Songs, songs);
			_dbHelper.RemoveItemsFromRelationLists(album.Songs, entity.Songs);


			var genres = _context.Genres.ToList()
										.Where(g => entity.Genres
														  .Exists(el => el.Id == g.Id)).ToList();

			_dbHelper.AddItemsToRelationLists(album.Genres, genres);
			_dbHelper.RemoveItemsFromRelationLists(album.Genres, entity.Genres);

			await _context.SaveChangesAsync();
		}


	}
}

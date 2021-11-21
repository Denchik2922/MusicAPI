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
	public class SongService : BaseGenericService<Song>, ISongService
	{
		private IDbHelperService _dbHelper;

		public SongService(MusicContext context, IDbHelperService dbHelper) : base(context) {
			_dbHelper = dbHelper;
		}

		public Song GetByIdWithInclude(int id)
		{
			var songs = _context.Songs
				.AsNoTracking()
				.Where(m => m.Id == id);
			if (songs.Count() < 1)
			{
				throw new ArgumentNullException($"song with id - {id} not found");
			}

			return songs
				.Include(g => g.Genres)
				.FirstOrDefault();
		}


		public async override Task Add(Song entity)
		{
			_context.Genres.AttachRange(entity.Genres);
			await _context.Songs.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public override async Task Update(Song entity)
		{
			Song song = GetByIdWithInclude(entity.Id);
			song.Name = entity.Name;
			song.Length = entity.Length;
			song.Released = entity.Released;

			var genres = _context.Genres.ToList()
										.Where(g => entity.Genres
														  .Exists(el => el.Id == g.Id)).ToList();

			_dbHelper.AddItemsToRelationLists(song.Genres, genres);
			_dbHelper.RemoveItemsFromRelationLists(song.Genres, entity.Genres);


			song.MusicAlbumId = entity.MusicAlbumId;

			await _context.SaveChangesAsync();
		}

	}
}

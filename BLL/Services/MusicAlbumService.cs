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
		public MusicAlbumService(MusicContext context) : base(context) { }

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

		public async Task AddSongToAlbum(int albumId, Song song)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);
			musicAlbum.Songs.Add(song);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveSongToAlbum(int albumId, int songId)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);
			musicAlbum.Songs.RemoveAll(i => i.Id == songId);
			await _context.SaveChangesAsync();
		}

		public async Task AddGenreToAlbum(int albumId, Genre genre)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);
			musicAlbum.Genres.Add(genre);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveGenreToAlbum(int albumId, int genreId)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);
			musicAlbum.Genres.RemoveAll(i => i.Id == genreId);
			await _context.SaveChangesAsync();
		}
	}
}

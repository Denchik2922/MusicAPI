using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;


namespace BLL.Services
{
	public class MusicAlbumService : BaseGenericService<MusicAlbum>, IMusicAlbumService
	{
		public MusicAlbumService(MusicContext context) : base(context) { }

		public MusicAlbum GetByIdWithInclude(int id)
		{
			return _context.MusicAlbums
				.Where(m => m.Id == id)
				.Include(m => m.Genres)
				.Include(m => m.Songs)
				.FirstOrDefault();
		}

		public void AddSongToAlbum(int albumId, Song song)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);
			musicAlbum.Songs.Add(song);
			_context.SaveChanges();
		}

		public void RemoveSongToAlbum(int albumId, int songId)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId); ;
			musicAlbum.Songs.RemoveAll(i => i.Id == songId);
			_context.SaveChanges();
		}

		public void AddGenreToAlbum(int albumId, Genre genre)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);
			musicAlbum.Genres.Add(genre);
			_context.SaveChanges();
		}

		public void RemoveGenreToAlbum(int albumId, int genreId)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);
			musicAlbum.Genres.RemoveAll(i => i.Id == genreId);
			_context.SaveChanges();
		}
	}
}

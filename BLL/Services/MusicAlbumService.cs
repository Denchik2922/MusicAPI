using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Linq;


namespace BLL.Services
{
	public class MusicAlbumService : BaseGenericService<MusicAlbum>, IMusicAlbumService
	{
		public MusicAlbumService(MusicContext context, ILogger<MusicAlbumService> logger) : base(context, logger) { }

		public MusicAlbum GetByIdWithInclude(int id)
		{
			var musicAlbums = _context.MusicAlbums
				.Where(m => m.Id == id);
			if (musicAlbums.Count() < 1)
			{
				string ErrorMsg = $"Music Album with id - {id} not found";
				_logger.LogWarning(ErrorMsg);
				throw new Exception(ErrorMsg);
			}

			return musicAlbums
				.Include(m => m.Genres)
				.Include(m => m.Songs)
				.FirstOrDefault();
		}

		public void AddSongToAlbum(int albumId, Song song)
		{

			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);
			try
			{
				musicAlbum.Songs.Add(song);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				string ErrorMsg = $"Error adding song - {song.Name} to album with id - {albumId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}

		}

		public void RemoveSongToAlbum(int albumId, int songId)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);
			try
			{
				musicAlbum.Songs.RemoveAll(i => i.Id == songId);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				string ErrorMsg = $"Error removing songId - {songId} to album with id - {albumId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
			
		}

		public void AddGenreToAlbum(int albumId, Genre genre)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);

			try
			{
				musicAlbum.Genres.Add(genre);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				string ErrorMsg = $"Error adding genre - {genre.Name} to album with id - {albumId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
			
		}

		public void RemoveGenreToAlbum(int albumId, int genreId)
		{
			MusicAlbum musicAlbum = GetByIdWithInclude(albumId);

			try
			{
				musicAlbum.Genres.RemoveAll(i => i.Id == genreId);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				string ErrorMsg = $"Error removing genreId - {genreId} to album with id - {albumId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
			
		}
	}
}

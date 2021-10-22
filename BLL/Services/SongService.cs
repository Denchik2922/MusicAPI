using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Linq;

namespace BLL.Services
{
	public class SongService : BaseGenericService<Song>, ISongService
	{
		public SongService(MusicContext context, ILogger<SongService> logger) : base(context, logger) { }

		public Song GetByIdWithInclude(int id)
		{
			var songs = _context.Songs
				.Where(m => m.Id == id);
			if (songs.Count() < 1)
			{
				string ErrorMsg = $"song with id - {id} not found";
				_logger.LogWarning(ErrorMsg);
				throw new Exception(ErrorMsg);
			}

			return songs
				.Include(g => g.Genres)
				.FirstOrDefault();
		}
	}
}

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
		public SongService(MusicContext context, ILogger<SongService> logger) : base(context) { }

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
	}
}

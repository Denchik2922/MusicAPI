using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace BLL.Services
{
	public class SongService : BaseGenericService<Song>, ISongService
	{
		public SongService(MusicContext context) : base(context) { }

		public Song GetByIdWithInclude(int id)
		{
			return _context.Songs
				.Where(g => g.Id == id)
				.Include(g => g.Genres)
				.FirstOrDefault();
		}
	}
}

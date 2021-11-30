using AutoMapper;
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
		private IMapper _mapper;

		public SongService(MusicContext context, IMapper mapper) : base(context) {
			_mapper = mapper;
		}

		public async Task<Song> GetByIdWithInclude(int id)
		{
			var song = await _context.Songs
				.Include(s => s.GenreSongs)
				.ThenInclude(g => g.Genre)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (song == null)
			{
				throw new ArgumentNullException($"{typeof(Song).Name} item with id {id} not found.");
			}
			return song;
		}


		public override async Task Update(Song entity)
		{
			var song = await GetByIdWithInclude(entity.Id);
			_mapper.Map(entity, song);
			await base.Update(song);
		}

	}
}

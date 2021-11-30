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
	public class MusicAlbumService : BaseGenericService<MusicAlbum>, IMusicAlbumService
	{
		private IMapper _mapper;

		public MusicAlbumService(MusicContext context, IMapper mapper) : base(context) {
			_mapper = mapper;
		}

		public async Task<MusicAlbum> GetByIdWithInclude(int id)
		{
			var musicAlbum = await _context.MusicAlbums
				.Include(m => m.Songs)
				.Include(m => m.GenreMusicAlbums)
				.ThenInclude(g => g.Genre)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (musicAlbum == null)
			{
				throw new ArgumentNullException($"{typeof(MusicAlbum).Name} item with id {id} not found.");
			}
			return musicAlbum;
		}

		public async override Task Add(MusicAlbum entity)
		{
			_context.Songs.AttachRange(entity.Songs);
			await _context.MusicAlbums.AddAsync(entity);
			await _context.SaveChangesAsync();
		}


		public override async Task Update(MusicAlbum entity)
		{
			var album = await GetByIdWithInclude(entity.Id);
			_mapper.Map(entity, album);
			await base.Update(album);
		}


	}
}

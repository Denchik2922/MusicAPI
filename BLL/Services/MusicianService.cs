using AutoMapper;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BLL.Services
{
	public class MusicianService : BaseGenericService<Musician>, IMusicianService
	{

		private IMapper _mapper;

		public MusicianService(MusicContext context, IMapper mapper) : base(context) {
			_mapper = mapper;
		}
		
		public async Task<Musician> GetByIdWithInclude(int id)
		{
			var musician = await _context.Musicians
				.Include(m => m.MusicInstrumentMusicians)
				.ThenInclude(i => i.MusicInstrument)
				.Include(m => m.GenreMusicians)
				.ThenInclude(g => g.Genre)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (musician == null)
			{
				throw new ArgumentNullException($"{typeof(Musician).Name} item with id {id} not found.");
			}
			return musician;
		}

		public override async Task Update(Musician entity)
		{
			var musician = await GetByIdWithInclude(entity.Id);
			_mapper.Map(entity, musician);
			await base.Update(musician);
		}

	}
}

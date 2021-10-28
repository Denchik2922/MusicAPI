using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BLL.Services
{
	public class MusicianService : BaseGenericService<Musician>, IMusicianService
	{
		public MusicianService(MusicContext context) : base(context) { }
		
		public Musician GetByIdWithInclude(int id)
		{
			var musicians = _context.Musicians
				.Where(m => m.Id == id);
			if (musicians.Count() < 1)
			{
				throw new ArgumentNullException($"Musician with id - {id} not found");
			}

			return musicians.Include(m => m.Genres)
							.Include(m => m.Group)
							.Include(m => m.MusicInstruments)
							.FirstOrDefault();
		}

		public async Task AddInstrumentToMusician(int musicianId, MusicInstrument instrument)
		{
			Musician musician = GetByIdWithInclude(musicianId);
			musician.MusicInstruments.Add(instrument);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveInstrumentToMusician(int musicianId, int instrumentId)
		{
			Musician musician = GetByIdWithInclude(musicianId);
			musician.MusicInstruments.RemoveAll(i => i.Id == instrumentId);
			await _context.SaveChangesAsync();
	
			
		}

		public async Task AddGenreToMusician(int musicianId, Genre genre)
		{
			Musician musician = GetByIdWithInclude(musicianId);
			musician.Genres.Add(genre);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveGenreToMusician(int musicianId, int genreId)
		{
			Musician musician = GetByIdWithInclude(musicianId);
			musician.Genres.RemoveAll(i => i.Id == genreId);
			await _context.SaveChangesAsync();
		}
	}
}

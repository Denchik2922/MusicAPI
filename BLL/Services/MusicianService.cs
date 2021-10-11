using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace BLL.Services
{
	public class MusicianService : BaseGenericService<Musician>, IMusicianService
	{
		public MusicianService(MusicContext context) : base(context) { }
		
		public Musician GetByIdWithInclude(int id)
		{
			return _context.Musicians
				.Where(m => m.Id == id)
				.Include(m => m.Genres)
				.Include(m => m.Group)
				.Include(m => m.MusicInstruments)
				.FirstOrDefault();
		}

		public void AddInstrumentToMusician(int musicianId, MusicInstrument instrument)
		{
			Musician musician = GetByIdWithInclude(musicianId);
			musician.MusicInstruments.Add(instrument);
			_context.SaveChanges();
		}

		public void RemoveInstrumentToMusician(int musicianId, int instrumentId)
		{
			Musician musician = GetByIdWithInclude(musicianId);
			musician.MusicInstruments.RemoveAll(i => i.Id == instrumentId);
			_context.SaveChanges();
		}

		public void AddGenreToMusician(int musicianId, Genre genre)
		{
			Musician musician = GetByIdWithInclude(musicianId);
			musician.Genres.Add(genre);
			_context.SaveChanges();
		}

		public void RemoveGenreToMusician(int musicianId, int genreId)
		{
			Musician musician = GetByIdWithInclude(musicianId);
			musician.Genres.RemoveAll(i => i.Id == genreId);
			_context.SaveChanges();
		}
	}
}

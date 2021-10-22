using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BLL.Services
{
	public class MusicianService : BaseGenericService<Musician>, IMusicianService
	{
		public MusicianService(MusicContext context, ILogger<MusicianService> logger) : base(context, logger) { }
		
		public Musician GetByIdWithInclude(int id)
		{
			var musicians = _context.Musicians
				.Where(m => m.Id == id);
			if (musicians.Count() < 1)
			{
				string ErrorMsg = $"Musician with id - {id} not found";
				_logger.LogWarning(ErrorMsg);
				throw new ArgumentNullException(ErrorMsg);
			}

			return musicians.Include(m => m.Genres)
							.Include(m => m.Group)
							.Include(m => m.MusicInstruments)
							.FirstOrDefault();
		}

		public void AddInstrumentToMusician(int musicianId, MusicInstrument instrument)
		{
			Musician musician = GetByIdWithInclude(musicianId);

			try
			{
				musician.MusicInstruments.Add(instrument);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{

				string ErrorMsg = $"Error adding instrument - {instrument.Name} to musician with id - {musicianId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
			
		}

		public void RemoveInstrumentToMusician(int musicianId, int instrumentId)
		{
			Musician musician = GetByIdWithInclude(musicianId);

			try
			{
				musician.MusicInstruments.RemoveAll(i => i.Id == instrumentId);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				string ErrorMsg = $"Error removing instrumentId - {instrumentId} to musician with id - {musicianId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
			
		}

		public void AddGenreToMusician(int musicianId, Genre genre)
		{
			Musician musician = GetByIdWithInclude(musicianId);

			try
			{
				musician.Genres.Add(genre);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				string ErrorMsg = $"Error adding genre - {genre.Name} to musician with id - {musicianId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
		}

		public void RemoveGenreToMusician(int musicianId, int genreId)
		{
			Musician musician = GetByIdWithInclude(musicianId);

			try
			{
				musician.Genres.RemoveAll(i => i.Id == genreId);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				string ErrorMsg = $"Error removing genreId - {genreId} to musician with id - {musicianId}";
				_logger.LogError(ex, ErrorMsg);
				throw new Exception(ErrorMsg);
			}
			
		}
	}
}

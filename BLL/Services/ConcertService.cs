using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class ConcertService : BaseGenericService<Concert>, IConcertService
	{
		private readonly IConcertApiRepository _concertApi;

		public ConcertService(MusicContext context, IConcertApiRepository concertApi) : base(context)
		{
			_concertApi = concertApi;
		}


		public Concert GetByIdWithInclude(int id)
		{
			return _context.Concerts
				.Where(c => c.Id == id)
				.Include(c => c.Stats)
				.Include(c => c.Venue)
				.FirstOrDefault();
		}

		public override void Add(Concert entity)
		{
			if(entity.Id != 0)
			{
				entity.Id = 0;
				entity.Venue.Id = 0;
			}

			if (entity.Stats.Average_Price == null)
			{
				var rnd = new Random();

				Stat newStats = new Stat
				{
					Listing_Count = rnd.Next(20, 100).ToString(),
					Average_Price = rnd.Next(20, 60).ToString(),
					Lowest_Price = rnd.Next(20, 60).ToString(),
					Highest_Price = rnd.Next(60, 100).ToString(),
				};
				entity.Stats = newStats;
			}

			_dbSet.Add(entity);
			_context.SaveChanges();
		}

		private void AddRange(IEnumerable<Concert> concerts)
		{
			var newConcerts = concerts.Where(c => _context.Concerts.
															FirstOrDefault(con => con.Title.Contains(c.Title)) == default).
															ToList();
			foreach(var concert in newConcerts)
			{
				Add(concert);
			}
		} 

		public async Task<IEnumerable<Concert>> GetAllConcertsWithInclude()
		{
			var concerts = _context.Concerts
				.Include(c => c.Stats)
				.Include(c => c.Venue).ToList();

			if (concerts.Count <= 0 || concerts == null)
			{
				concerts = await _concertApi.GetAllConcerts();
				if(concerts != null)
				{
					AddRange(concerts);
				}
			}

			return concerts;
		}


	}
}

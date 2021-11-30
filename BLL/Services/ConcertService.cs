using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.ConcertAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class ConcertService : BaseGenericService<Concert>, IConcertService
	{
		public ConcertService(MusicContext context) : base(context){}


		public async Task<Concert> GetByIdWithInclude(int id)
		{

			var concert = await _context.Concerts
				.Include(c => c.Stats)
				.Include(c => c.Venue)
				.FirstOrDefaultAsync(m => m.Id == id);

			if (concert == null)
			{
				throw new ArgumentNullException($"{typeof(Concert).Name} item with id {id} not found.");
			}
			return concert;
		}

		public override async Task Add(Concert entity)
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

			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveConcerts(IEnumerable<Concert> concerts)
		{
			_dbSet.RemoveRange(concerts);
			await _context.SaveChangesAsync();
		}

		public async Task AddRange(IEnumerable<Concert> concerts)
		{
			var newConcerts = concerts.Where(c => _context.Concerts.
															FirstOrDefault(con => con.Title.Contains(c.Title)) == default).
															ToList();
			foreach(var concert in newConcerts)
			{
				await Add(concert);
			}
		} 

		public async Task<IEnumerable<Concert>> GetAllConcertsWithInclude()
		{
			var concerts = await _context.Concerts
				.Include(c => c.Stats)
				.Include(c => c.Venue)
				.OrderBy(c => c.Datetime_Local)
				.ToListAsync();

			return concerts;
		}

	}
}

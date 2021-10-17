using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
	public class StatisticService : IStatisticService
	{
		private readonly MusicContext _context;

		public StatisticService(MusicContext context)
		{
			_context = context;
		}

		public IEnumerable<object> GetFivePopularInstruments()
		{
			var instrumens = _context.MusicInstruments.
				Include(i => i.Musicians).
				OrderByDescending(i => i.Musicians.Count).
				Take(5).
				Select(i => new { Name = i.Name, MusiciansUsed = i.Musicians.Count });

			return instrumens;
		}

		public double GetAverageCostConcertPerMonth(int mouth)
		{
			var avarage = _context.Concerts.
				Include(c => c.Stats).
				ToList().
				Where(c => c.Datetime_Local.Month == mouth).
				Average(c => double.Parse(c.Stats.Average_Price.Trim()));
				
			return avarage;
		}


		public IEnumerable<object> GetCountriesWithMostMusicians()
		{
			var countries = _context.Musicians.
				Include(m => m.MusicInstruments).
				ToList().
				GroupBy(m => m.Country).
				Select(g => new
				{
					Country = g.Key,
					Musician = g.GroupBy(i => i.MusicInstruments.Select(i => i.Name).First().ToString()).
							Select(g => new { Instrument = g.Key, Count = g.Count() }).
							OrderByDescending(i => i.Count)
				});
			return countries;
		}

	}
}

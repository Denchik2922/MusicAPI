using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ModelsDto;

namespace BLL.Services
{
	public class StatisticService : IStatisticService
	{
		private readonly MusicContext _context;
		private readonly ILogger<StatisticService> _logger;

		public StatisticService(MusicContext context, ILogger<StatisticService> logger)
		{
			_context = context;
			_logger = logger;
		}

		public IEnumerable<PopularInstrumentsDto> GetFivePopularInstruments()
		{
			var instrumens = _context.MusicInstruments.
				Include(i => i.Musicians).
				AsNoTracking().
				Where(i => i.Musicians.Count > 0).
				OrderByDescending(i => i.Musicians.Count).
				Take(5).
				Select(i => new PopularInstrumentsDto { Name = i.Name, MusiciansUsed = i.Musicians.Count });

			return instrumens;
		}

		public double GetAverageCostConcertPerMonth(int mouth)
		{
			var avarage = _context.Concerts.
				Include(c => c.Stats).
				AsNoTracking().
				ToList().
				Where(c => c.Datetime_Local.Month == mouth).
				Average(c => ParseAveragePrice(c.Stats.Average_Price.Trim()));

			return avarage;
		}

		private double ParseAveragePrice(string averagePriceStr)
		{
			double price;
			if (!double.TryParse(averagePriceStr, out price))
			{
				_logger.LogError($"Double parse error with average price({averagePriceStr})");
			}
			return price;
			
		}

		public IEnumerable<CountryWithMusiciansDto> GetCountriesWithMostMusicians()
		{
			var countries = _context.Musicians.
				Include(m => m.MusicInstruments).
				AsNoTracking().
				ToList().
				GroupBy(m => m.Country).
				Select(g => new CountryWithMusiciansDto
				{
					Country = g.Key,
					Musician = g.GroupBy(i => i.MusicInstruments.Select(i => i.Name).First().ToString()).
							Select(g => new MusicianCountryDto { Instrument = g.Key, Count = g.Count() }).
							OrderByDescending(i => i.Count)
				});
			return countries;
		}

	}
}
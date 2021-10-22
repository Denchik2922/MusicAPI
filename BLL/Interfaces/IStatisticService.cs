using BLL.ModelsService;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
	public interface IStatisticService
	{
		IEnumerable<PopularInstruments> GetFivePopularInstruments();
		double GetAverageCostConcertPerMonth(int month);
		IEnumerable<CountryWithMusicians> GetCountriesWithMostMusicians();
	}
}
using ModelsDto;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
	public interface IStatisticService
	{
		IEnumerable<PopularInstrumentsDto> GetFivePopularInstruments();
		double GetAverageCostConcertPerMonth(int month);
		IEnumerable<CountryWithMusiciansDto> GetCountriesWithMostMusicians();
	}
}
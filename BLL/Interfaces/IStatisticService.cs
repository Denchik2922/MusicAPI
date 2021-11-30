using ModelsDto.StatisticDto;
using System.Collections.Generic;

namespace BLL.Interfaces
{
	public interface IStatisticService
	{
		IEnumerable<PopularInstrumentsDto> GetFivePopularInstruments();
		double GetAverageCostConcert();
		IEnumerable<CountryWithMusiciansDto> GetCountriesWithMostMusicians();
	}
}
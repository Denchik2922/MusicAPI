using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
	public interface IStatisticService
	{
		IEnumerable<object> GetFivePopularInstruments();
		double GetAverageCostConcertPerMonth(int month);
		IEnumerable<object> GetCountriesWithMostMusicians();
	}
}
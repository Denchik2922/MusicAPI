using System.Collections.Generic;

namespace ModelsDto.StatisticDto
{
	public class CountryWithMusiciansDto
	{
		public string Country { get; set; }
		public IEnumerable<MusicianCountryDto> Musician { get; set; }
	}
}

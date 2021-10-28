using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDto
{
	public class CountryWithMusiciansDto
	{
		public string Country { get; set; }
		public IEnumerable<MusicianCountryDto> Musician { get; set; }
	}
}

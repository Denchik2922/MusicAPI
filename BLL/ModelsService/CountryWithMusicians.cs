using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsService
{
	public class CountryWithMusicians
	{
		public string Country { get; set; }
		public IEnumerable<MusicianCountry> Musician { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsDto
{
	public class ConcertDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public StatDto Stats { get; set; }
		public double Popularity { get; set; }
		public DateTime Datetime_Local { get; set; }
		public VenueDto Venue { get; set; }
	}
}

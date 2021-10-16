using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAPI.ModelsDTO
{
	public class ConcertDTO
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public StatDTO Stats { get; set; }
		public double Popularity { get; set; }
		public DateTime Datetime_Local { get; set; }
		public VenueDTO Venue { get; set; }
	}
}

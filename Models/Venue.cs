using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Venue
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Timezone { get; set; }
		public string Display_location { get; set; }
		public int ConcertId { get; set; }
		public Concert Concert { get; set; }
	}
}

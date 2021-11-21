using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Stat : IEntity
	{
		public int Id { get; set; }
		public string Listing_Count { get; set; }
		public string Average_Price { get; set; }
		public string Lowest_Price { get; set; }
		public string Highest_Price { get; set; }
		public int ConcertId { get; set; }
		public Concert Concert { get; set; }
	}
}

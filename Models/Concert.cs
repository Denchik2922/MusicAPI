using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Concert : IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public Stat Stats { get; set; }
		public double Popularity { get; set; }
		public DateTime Datetime_Local { get; set; }
		public Venue Venue { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Models
{
	public class Group
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public List<Musician> Members { get; set; } = new List<Musician>();
		public List<Genre> Genres { get; set; } = new List<Genre>();

	}
}

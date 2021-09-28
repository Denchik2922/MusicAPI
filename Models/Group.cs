using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Models
{
	public sealed class Group
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		[MaxLength(40)]
		public string Country { get; set; }
		public List<Musician> Members { get; set; } = new List<Musician>();
		public List<Genre> Genres { get; set; } = new List<Genre>();

	}
}

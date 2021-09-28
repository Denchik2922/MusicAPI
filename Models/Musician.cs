using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Models
{
	public sealed class Musician
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(50)]
		public string LastName { get; set; }

		[Required]
		[MaxLength(40)]
		public string Country { get; set; }

		public List<MusicInstrument> MusicInstruments { get; set; } = new List<MusicInstrument>();
		public List<Genre> Genres { get; set; } = new List<Genre>();
		public int GroupId { get; set; }
		public Group Group { get; set; }
	}
}

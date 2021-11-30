using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Models
{
	public class Musician
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Country { get; set; }

		public ICollection<MusicInstrumentMusician> MusicInstrumentMusicians { get; set; } = new List<MusicInstrumentMusician>();
		public ICollection<GenreMusician> GenreMusicians { get; set; } = new List<GenreMusician>();

		public int GroupId { get; set; }
		public Group Group { get; set; }
	}
}

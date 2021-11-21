using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Models
{
	public class Musician : IEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Country { get; set; }
		public List<MusicInstrument> MusicInstruments { get; set; } = new List<MusicInstrument>();
		public List<Genre> Genres { get; set; } = new List<Genre>();
		public int GroupId { get; set; }
		public Group Group { get; set; }
	}
}

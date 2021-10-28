using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsDto
{
	public class MusicianDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Country { get; set; }
		public List<MusicInstrumentDto> MusicInstruments { get; set; }
		public List<GenreDto> Genres { get; set; }
		public int GroupId { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ModelsDTO
{
	public class MusicianDTO
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Country { get; set; }
		public List<MusicInstrumentDTO> MusicInstruments { get; set; }
		public List<GenreDTO> Genres { get; set; }
		public int GroupId { get; set; }
		public GroupDTO Group { get; set; }

	}
}

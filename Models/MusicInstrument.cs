using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class MusicInstrument
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public ICollection<MusicInstrumentMusician> MusicInstrumentMusicians { get; set; } = new List<MusicInstrumentMusician>();
	}
}

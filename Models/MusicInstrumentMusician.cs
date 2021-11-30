using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class MusicInstrumentMusician
	{
		public int MusicianId { get; set; }
		public Musician Musician { get; set; }

		public int MusicInstrumentId { get; set; }
		public MusicInstrument MusicInstrument { get; set; }
	}
}

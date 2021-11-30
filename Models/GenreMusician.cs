using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class GenreMusician
	{
		public int MusicianId { get; set; }
		public Musician Musician { get; set; }

		public int GenreId { get; set; }
		public Genre Genre { get; set; }
	}
}

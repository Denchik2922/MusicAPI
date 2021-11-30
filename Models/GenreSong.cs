using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class GenreSong
	{
		public int SongId { get; set; }
		public Song Song { get; set; }

		public int GenreId { get; set; }
		public Genre Genre { get; set; }
	}
}

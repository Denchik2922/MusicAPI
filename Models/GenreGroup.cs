using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class GenreGroup
	{
		public int GroupId { get; set; }
		public Group Group { get; set; }

		public int GenreId { get; set; }
		public Genre Genre { get; set; }
	}
}

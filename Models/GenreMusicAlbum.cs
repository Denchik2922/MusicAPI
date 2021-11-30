using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class GenreMusicAlbum
	{
		public int MusicAlbumId { get; set; }
		public MusicAlbum MusicAlbum { get; set; }

		public int GenreId { get; set; }
		public Genre Genre { get; set; }
	}
}

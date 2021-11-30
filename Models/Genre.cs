using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
 	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<GenreMusician> GenreMusicians { get; set; } = new List<GenreMusician>();
		public ICollection<GenreMusicAlbum> GenreMusicAlbums { get; set; } = new List<GenreMusicAlbum>();
		public ICollection<GenreGroup> GenreGroups { get; set; } = new List<GenreGroup>();
		public ICollection<GenreSong> GenreSongs { get; set; } = new List<GenreSong>();
	}
}

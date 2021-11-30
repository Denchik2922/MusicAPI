using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Models
{
	public class Group
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public ICollection<Musician> Members { get; set; } = new List<Musician>();
		public ICollection<MusicAlbum> MusicAlbums { get; set; } = new List<MusicAlbum>();
		public ICollection<GenreGroup> GenreGroups { get; set; } = new List<GenreGroup>();

	}
}

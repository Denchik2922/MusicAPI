using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
 	public class Genre : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Musician> Musicians { get; set; } = new List<Musician>();
		public List<Group> Groups { get; set; } = new List<Group>();
		public List<Song> Songs { get; set; } = new List<Song>();
		public List<MusicAlbum> MusicAlbums { get; set; } = new List<MusicAlbum>();
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class MusicAlbum
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }
		public TimeSpan Length { get; set; }
		public ICollection<Song> Songs { get; set; } = new List<Song>();
		public int GroupId { get; set; }
		public Group Group { get; set; }
		public ICollection<GenreMusicAlbum> GenreMusicAlbums { get; set; } = new List<GenreMusicAlbum>();
	}
}

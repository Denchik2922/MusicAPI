using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class Song
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }
		public TimeSpan Length { get; set; }
		public int MusicAlbumId { get; set; }
		public MusicAlbum MusicAlbum { get; set; }
		public ICollection<GenreSong> GenreSongs { get; set; } = new List<GenreSong>();
	}
}

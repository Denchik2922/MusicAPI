using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public sealed class Song
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		public DateTime Released { get; set; }

		[Required]
		public TimeSpan Length { get; set; }
		public int MusicAlbumId { get; set; }
		public MusicAlbum MusicAlbum { get; set; }
		public List<Genre> Genres { get; set; } = new List<Genre>();
	}
}

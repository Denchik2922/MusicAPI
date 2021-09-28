using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public sealed class MusicAlbum
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		public DateTime Released { get; set; }

		[Required]
		public TimeSpan Length { get; set; }
		public List<Song> Songs { get; set; } = new List<Song>();
		public int GroupId { get; set; }
		public Group Group { get; set; }
		public List<Genre> Genres { get; set; } = new List<Genre>();
	}
}

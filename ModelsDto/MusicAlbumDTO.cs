using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace ModelsDto
{
	public class MusicAlbumDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }

		[JsonConverter(typeof(JsonTimeSpanConverter))]
		public TimeSpan Length { get; set; }
		public List<SongDto> Songs { get; set; }
		public int GroupId { get; set; }
		public List<GenreDto> Genres { get; set; }
	}
}

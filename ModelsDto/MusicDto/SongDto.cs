using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ModelsDto.MusicDto
{
	public class SongDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }

		[JsonConverter(typeof(TimeSpanConverter))]
		public TimeSpan Length { get; set; }

		public int MusicAlbumId { get; set; }
	}
}

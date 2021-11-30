using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ModelsDto.MusicDto
{
	public class MusicAlbumDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }

		[JsonConverter(typeof(JsonTimeSpanConverter))]
		public TimeSpan Length { get; set; }

		public int GroupId { get; set; }
	}
}

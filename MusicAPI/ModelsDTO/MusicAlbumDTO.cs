using MusicAPI.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicAPI.ModelsDto
{
	public class MusicAlbumDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }

		[JsonConverter(typeof(TimeSpanConverter))]
		public TimeSpan Length { get; set; }
		public List<SongDto> Songs { get; set; }
		public int GroupId { get; set; }
		public List<GenreDto> Genres { get; set; }
	}
}

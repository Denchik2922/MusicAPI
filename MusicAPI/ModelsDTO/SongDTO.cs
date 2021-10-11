using MusicAPI.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicAPI.ModelsDTO
{
	public class SongDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }

		[JsonConverter(typeof(TimeSpanConverter))]
		public TimeSpan Length { get; set; }
		public int MusicAlbumId { get; set; }
		public List<GenreDTO> Genres { get; set; }
	}
}

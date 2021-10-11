using MusicAPI.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicAPI.ModelsDTO
{
	public class MusicAlbumDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }

		[JsonConverter(typeof(TimeSpanConverter))]
		public TimeSpan Length { get; set; }
		public List<SongDTO> Songs { get; set; }
		public int GroupId { get; set; }
		public List<GenreDTO> Genres { get; set; }
	}
}

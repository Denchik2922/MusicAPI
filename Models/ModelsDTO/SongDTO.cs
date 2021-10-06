using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ModelsDTO
{
	public class SongDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }
		public TimeSpan Length { get; set; }
		public int MusicAlbumId { get; set; }
		public MusicAlbumDTO MusicAlbum { get; set; }
		public List<GenreDTO> Genres { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ModelsDTO
{
	public class MusicAlbumDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }
		public TimeSpan Length { get; set; }
		public List<SongDTO> Songs { get; set; }
		public int GroupId { get; set; }
		public GroupDTO Group { get; set; }
		public List<GenreDTO> Genres { get; set; }
	}
}

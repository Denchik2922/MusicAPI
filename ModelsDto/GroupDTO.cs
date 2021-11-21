using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDto
{
	public class GroupDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public List<MusicianDto> Members { get; set; }
		public List<MusicAlbumDto> MusicAlbums { get; set; }
		public List<GenreDto> Genres { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ModelsDTO
{
	public class GroupDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public List<GenreDTO> Genres { get; set; }
	}
}

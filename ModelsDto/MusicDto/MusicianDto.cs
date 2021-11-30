using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelsDto.MusicDto
{
	public class MusicianDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Country { get; set; }
		public int GroupId { get; set; }
	}
}

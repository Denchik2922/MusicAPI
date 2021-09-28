using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public sealed class MusicInstrument
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		[MaxLength(100)]
		public string Description { get; set; }
		public List<Musician> Musicians { get; set; } = new List<Musician>();
	}
}

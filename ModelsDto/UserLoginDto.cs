using System.ComponentModel.DataAnnotations;

namespace ModelsDto
{
	public class UserLoginDto
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}

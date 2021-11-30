using System.ComponentModel.DataAnnotations;

namespace ModelsDto.AuthDto
{
	public class UserLoginDto
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsDto
{
	public class UserDto
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public RoleDto Role { get; set; }
	}
}

using Microsoft.AspNetCore.Identity;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IAuthService
	{
		Task<string> Authenticate(string username, string password);
		Task<IEnumerable<IdentityUser>> GetAll();
		Task Register(IdentityUser user, string password);
	}
}
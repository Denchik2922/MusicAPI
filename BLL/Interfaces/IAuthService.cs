using Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IAuthService : IGenericService<User>
	{
		string Authenticate(string username, string password);
		User GetByIdWithInclude(int id);
		Task Register(User user);
	}
}
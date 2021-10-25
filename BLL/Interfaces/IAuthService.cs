using Models;

namespace BLL.Interfaces
{
	public interface IAuthService : IGenericService<User>
	{
		string Authenticate(string username, string password);
		User GetByIdWithInclude(int id);
		void Register(User user);
	}
}
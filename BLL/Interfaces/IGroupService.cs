using Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IGroupService : IGenericService<Group>
	{
		Task<Group> GetByIdWithInclude(int id);
	}
}
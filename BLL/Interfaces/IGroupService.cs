using Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IGroupService : IGenericService<Group>
	{
		Group GetByIdWithInclude(int id);
	}
}
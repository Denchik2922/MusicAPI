using Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IGroupService : IGenericService<Group>
	{
		Task AddGenreToGroup(int groupId, Genre genre);
		Task AddMemberToGroup(int groupId, Musician musician);
		Group GetByIdWithInclude(int id);
		Task RemoveGenreToGroup(int groupId, int genreId);
		Task RemoveMemberToGroup(int groupId, int memberId);
	}
}
using Models;

namespace BLL.Interfaces
{
	public interface IGroupService : IGenericService<Group>
	{
		void AddGenreToGroup(int groupId, Genre genre);
		void AddMemberToGroup(int groupId, Musician musician);
		Group GetByIdWithInclude(int id);
		void RemoveGenreToGroup(int groupId, int genreId);
		void RemoveMemberToGroup(int groupId, int memberId);
	}
}
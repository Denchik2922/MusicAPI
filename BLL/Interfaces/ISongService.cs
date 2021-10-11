using Models;

namespace BLL.Interfaces
{
	public interface ISongService : IGenericService<Song>
	{
		Song GetByIdWithInclude(int id);
	}
}
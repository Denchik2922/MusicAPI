using Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface ISongService : IGenericService<Song>
	{
		Task<Song> GetByIdWithInclude(int id);
	}
}
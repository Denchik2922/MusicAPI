using Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IMusicAlbumService : IGenericService<MusicAlbum>
	{
		Task<MusicAlbum> GetByIdWithInclude(int id);
	}
}
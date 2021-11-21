using Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IMusicAlbumService : IGenericService<MusicAlbum>
	{
		MusicAlbum GetByIdWithInclude(int id);
	}
}
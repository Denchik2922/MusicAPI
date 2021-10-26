using Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IMusicAlbumService : IGenericService<MusicAlbum>
	{
		Task AddGenreToAlbum(int albumId, Genre genre);
		Task AddSongToAlbum(int albumId, Song song);
		MusicAlbum GetByIdWithInclude(int id);
		Task RemoveGenreToAlbum(int albumId, int genreId);
		Task RemoveSongToAlbum(int albumId, int songId);
	}
}
using Models;

namespace BLL.Interfaces
{
	public interface IMusicAlbumService : IGenericService<MusicAlbum>
	{
		void AddGenreToAlbum(int albumId, Genre genre);
		void AddSongToAlbum(int albumId, Song song);
		MusicAlbum GetByIdWithInclude(int id);
		void RemoveGenreToAlbum(int albumId, int genreId);
		void RemoveSongToAlbum(int albumId, int songId);
	}
}
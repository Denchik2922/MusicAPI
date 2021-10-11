using Models;

namespace BLL.Interfaces
{
	public interface IMusicianService : IGenericService<Musician>
	{
		Musician GetByIdWithInclude(int id);
		void AddInstrumentToMusician(int musicianId, MusicInstrument instrument);
		void RemoveInstrumentToMusician(int musicianId, int instrumentId);
		void AddGenreToMusician(int musicianId, Genre genre);
		void RemoveGenreToMusician(int musicianId, int genreId);
	}
}
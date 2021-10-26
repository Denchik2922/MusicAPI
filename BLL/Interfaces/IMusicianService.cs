using Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IMusicianService : IGenericService<Musician>
	{
		Musician GetByIdWithInclude(int id);
		Task AddInstrumentToMusician(int musicianId, MusicInstrument instrument);
		Task RemoveInstrumentToMusician(int musicianId, int instrumentId);
		Task AddGenreToMusician(int musicianId, Genre genre);
		Task RemoveGenreToMusician(int musicianId, int genreId);
	}
}
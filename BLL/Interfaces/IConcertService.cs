using Models;
using Models.ConcertAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IConcertService : IGenericService<Concert>
	{
		Task<IEnumerable<Concert>> GetAllConcertsWithInclude();
		Task<Concert> GetByIdWithInclude(int id);
		Task AddRange(IEnumerable<Concert> concerts);
		Task RemoveConcerts(IEnumerable<Concert> concerts);
	}
}
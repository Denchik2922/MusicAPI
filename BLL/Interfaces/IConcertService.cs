using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IConcertService
	{
		Task Add(Concert entity);
		Task<IEnumerable<Concert>> GetAllConcertsWithInclude();
		Concert GetByIdWithInclude(int id);
	}
}
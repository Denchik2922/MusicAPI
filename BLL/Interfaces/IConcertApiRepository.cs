using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IConcertApiRepository
	{
		Task<List<Concert>> GetAllConcerts();
	}
}
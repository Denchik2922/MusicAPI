using Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IMusicianService : IGenericService<Musician>
	{
		Musician GetByIdWithInclude(int id);
	}
}
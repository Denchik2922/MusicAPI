using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IConcertJob
	{
		Task AddNewConcerts();
		Task DeleteOldConcerts();
	}
}
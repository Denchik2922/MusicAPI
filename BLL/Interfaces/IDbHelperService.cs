using Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
	public interface IDbHelperService
	{
		void AddItemsToRelationLists<T>(List<T> dbList, List<T> newItems) where T : IEntity;
		void RemoveItemsFromRelationLists<T>(List<T> dbList, List<T> newItems) where T : IEntity;
	}
}
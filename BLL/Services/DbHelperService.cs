using BLL.Interfaces;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
	public class DbHelperService : IDbHelperService
	{
		public void AddItemsToRelationLists<T>(List<T> dbList, List<T> newItems) where T : IEntity
		{
			dbList.AddRange(newItems.Where(el => !dbList.Exists(el2 => el2.Id == el.Id)).ToList());
		}

		public void RemoveItemsFromRelationLists<T>(List<T> dbList, List<T> newItems) where T : IEntity
		{
			dbList.RemoveAll(el => !newItems.Exists(el2 => el2.Id == el.Id));
		}
	}
}

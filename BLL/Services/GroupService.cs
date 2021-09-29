using BLL.Interfaces;
using DAL;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
	public sealed class GroupService : IGroupService
	{
		private readonly MusicContext _context;

		public GroupService(MusicContext context)
		{
			_context = context;
		}

		public List<Group> GetAllGroup()
		{
			return _context.Groups.ToList();
		}

	}
}

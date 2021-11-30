using AutoMapper;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class GroupService : BaseGenericService<Group>, IGroupService
	{
		private IMapper _mapper;

		public GroupService(MusicContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
		}

		public async Task<Group> GetByIdWithInclude(int id)
		{
			var group = await _context.Groups
				.Include(gr => gr.Members)
				.Include(gr => gr.GenreGroups)
				.ThenInclude(g => g.Genre)
				.Include(gr => gr.MusicAlbums)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (group == null)
			{
				throw new ArgumentNullException($"{typeof(Group).Name} item with id {id} not found.");
			}
			return group;

		}

		public async override Task Add(Group entity)
		{
			_context.Musicians.AttachRange(entity.Members);
			_context.MusicAlbums.AttachRange(entity.MusicAlbums);
			await _context.Groups.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public override async Task Update(Group entity)
		{
			var group = await GetByIdWithInclude(entity.Id);
			_mapper.Map(entity, group);
			await base.Update(group);
		}

	}
}

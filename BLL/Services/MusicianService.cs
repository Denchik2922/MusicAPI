using AutoMapper;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BLL.Services
{
	public class MusicianService : BaseGenericService<Musician>, IMusicianService
	{

		private IDbHelperService _dbHelper;
		public MusicianService(MusicContext context, IDbHelperService dbHelper) : base(context) {
			_dbHelper = dbHelper;
		}
		
		public Musician GetByIdWithInclude(int id)
		{
			var musicians = _context.Musicians
				.Where(m => m.Id == id);
			if (musicians.Count() < 1)
			{
				throw new ArgumentNullException($"Musician with id - {id} not found");
			}

			return musicians.Include(m => m.Genres)
							.Include(m => m.Group)
							.Include(m => m.MusicInstruments)
							.FirstOrDefault();
		}

		public async override Task Add(Musician entity)
		{
			_context.Genres.AttachRange(entity.Genres);
			_context.MusicInstruments.AttachRange(entity.MusicInstruments);
			await _context.Musicians.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public override async Task Update(Musician entity)
		{
			Musician musician = GetByIdWithInclude(entity.Id);
			musician.FirstName = entity.FirstName;
			musician.LastName = entity.LastName;
			musician.Country = entity.Country;

			var instruments = _context.MusicInstruments.ToList()
										.Where(i => entity.MusicInstruments
														  .Exists(el => el.Id == i.Id)).ToList();

			_dbHelper.AddItemsToRelationLists(musician.MusicInstruments, instruments);
			_dbHelper.RemoveItemsFromRelationLists(musician.MusicInstruments, entity.MusicInstruments);


			var genres = _context.Genres.ToList()
										.Where(g => entity.Genres
													      .Exists(el => el.Id == g.Id)).ToList();

			_dbHelper.AddItemsToRelationLists(musician.Genres, genres);
			_dbHelper.RemoveItemsFromRelationLists(musician.Genres, entity.Genres);


			musician.GroupId = entity.GroupId;

			await _context.SaveChangesAsync();
		}

	}
}

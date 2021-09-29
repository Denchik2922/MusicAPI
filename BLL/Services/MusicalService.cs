using BLL.Interfaces;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
	public sealed class MusicalService : IMusicalService
	{
		private readonly DBContext _context;

		public MusicalService(DBContext context)
		{
			_context = context;
		}

		public List<Musician> GetAllMusicians()
		{
			return _context.Musicians.ToList();
		}

	}
}

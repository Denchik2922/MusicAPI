using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL
{
	class DBContexFactory : IDesignTimeDbContextFactory<DBContext>
	{
		public DBContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<DBContext>()
				.UseSqlServer("Data Source=DESKTOP-8OHJ49P;Initial Catalog=DBMusic;Integrated Security=True;MultipleActiveResultSets=True");
			return new DBContext(builder.Options);
		}
	}
}

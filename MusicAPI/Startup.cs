using BLL.Interfaces;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using MusicAPI.Infrastructure;
using System;

namespace MusicAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers().AddNewtonsoftJson(options =>
			options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicAPI", Version = "v1" });

				var filePath = Path.Combine(System.AppContext.BaseDirectory, "MusicApi.xml");
				c.IncludeXmlComments(filePath);
			});

			//Add HttpClient
			services.AddHttpClient<IConcertApiRepository, ConcertApiRepository>();

			//Add DbContext
			services.AddDbContext<MusicContext>(options =>
			   options.UseSqlServer(Configuration.GetConnectionString("DB_CONN_STR")));

			//Add Services
			services.AddScoped(typeof(IGenericService<>), typeof(BaseGenericService<>));
			services.AddScoped<IMusicianService, MusicianService>();
			services.AddScoped<IGroupService, GroupService>();
			services.AddScoped<ISongService, SongService>();
			services.AddScoped<IMusicAlbumService, MusicAlbumService>();
			services.AddScoped<IConcertService, ConcertService>();
			services.AddSingleton<IConcertApiRepository, ConcertApiRepository>();

			//Add AutoMapper
			services.AddAutoMapper(typeof(Startup));
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicAPI v1"));
			}


			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

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
using System;
using Microsoft.Extensions.Logging;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MusicAPI.Middleware;
using Microsoft.AspNetCore.Identity;
using Hangfire;
using MusicAPI.Infrastructure.Profiles;

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

			//Configure Identity
			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<MusicContext>();

			services.Configure<IdentityOptions>(options =>
			{
				options.User.RequireUniqueEmail = true;
			});

			//Configure jwt authentication
			var secret = Configuration.GetSection("JwtSettings")["Secret"];

			var key = Encoding.ASCII.GetBytes(secret);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
		   .AddJwtBearer(x =>
		   {
			   x.RequireHttpsMetadata = false;
			   x.SaveToken = true;
			   x.TokenValidationParameters = new TokenValidationParameters
			   {
				   ValidateIssuerSigningKey = true,
				   IssuerSigningKey = new SymmetricSecurityKey(key),
				   ValidateIssuer = false,
				   ValidateAudience = false
			   };
		   });

			//Swagger
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicAPI", Version = "v1" });

				var filePath = Path.Combine(System.AppContext.BaseDirectory, "MusicApi.xml");
				c.IncludeXmlComments(filePath);
			});

			//Configure Hangfire
			services.AddHangfire(x =>
			{
				x.UseSqlServerStorage(Configuration.GetConnectionString("DbHangfire"));
			});
			services.AddHangfireServer();

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
			services.AddScoped<IStatisticService, StatisticService>();
			services.AddScoped<IAuthService, AuthService>();
			services.AddSingleton<IConcertApiRepository, ConcertApiRepository>();
			services.AddTransient<IConcertJob, ConcertJob>();



			//Add AutoMapper
			services.AddAutoMapper(typeof(MusicianProfile),
								   typeof(GenreProfile),
								   typeof(InstrumentProfile),
								   typeof(GroupProfile),
								   typeof(SongProfile),
								   typeof(AlbumProfile),
								   typeof(AuthProfile),
								   typeof(ConcertProfile));

			services.AddCors();
		}

		public void Configure(IApplicationBuilder app,
							  IWebHostEnvironment env,
							  ILoggerFactory loggerFactory,
							  IRecurringJobManager recurringJobManager,
							  IServiceProvider serviceProvider)
		{
			var path = Directory.GetCurrentDirectory();
			loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicAPI v1"));
			}

			app.UseMiddleware<ExceptionMiddleware>(loggerFactory.CreateLogger(nameof(ExceptionMiddleware)));

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
							.AllowAnyMethod()
							.AllowAnyHeader());

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			//Add hangfire
			app.UseHangfireDashboard();
			recurringJobManager.AddOrUpdate(
				"Add new concerts job",
				() => serviceProvider.GetService<IConcertJob>().AddNewConcerts(),
				" 0 6 * * *"
				);

			recurringJobManager.AddOrUpdate(
				"Delete old concerts",
				() => serviceProvider.GetService<IConcertJob>().DeleteOldConcerts(),
				"59 23 * * *"
				); ;
		}
	}
}

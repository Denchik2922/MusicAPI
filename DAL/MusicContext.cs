using System;
using System.Collections.Generic;
using System.Text;
using DAL.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ConcertAPI;

namespace DAL
{
	public sealed class MusicContext : IdentityDbContext
	{
		public MusicContext(DbContextOptions<MusicContext> options): base(options) { }

		public DbSet<Genre> Genres { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<MusicAlbum> MusicAlbums { get; set; }
		public DbSet<Musician> Musicians { get; set; }
		public DbSet<MusicInstrument> MusicInstruments { get; set; }
		public DbSet<Song> Songs { get; set; }
		public DbSet<Concert> Concerts { get; set; }
		public DbSet<Stat> Stats { get; set; }
		public DbSet<Venue> Venues { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new RoleConfiguration());
			modelBuilder.ApplyConfiguration(new GenreConfiguration());
			modelBuilder.ApplyConfiguration(new GenreGroupConfiguration());
			modelBuilder.ApplyConfiguration(new GenreMusicAlbumConfiguration());
			modelBuilder.ApplyConfiguration(new GenreMusicianConfiguration());
			modelBuilder.ApplyConfiguration(new GenreSongConfiguration());
			modelBuilder.ApplyConfiguration(new GroupConfiguration());
			modelBuilder.ApplyConfiguration(new InstrumentConfiguration());
			modelBuilder.ApplyConfiguration(new MusicAlbumConfiguration());
			modelBuilder.ApplyConfiguration(new MusicianConfiguration());
			modelBuilder.ApplyConfiguration(new MusicianInstrumentConfiguration());
			modelBuilder.ApplyConfiguration(new SongConfiguration());
		}
	}
}

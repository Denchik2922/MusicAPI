﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
	public sealed class MusicContext : DbContext
	{
		public MusicContext(DbContextOptions<MusicContext> options): base(options) { }

		public DbSet<Genre> Genres { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<MusicAlbum> MusicAlbums { get; set; }
		public DbSet<Musician> Musicians { get; set; }
		public DbSet<MusicInstrument> MusicInstruments { get; set; }
		public DbSet<Song> Songs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Musician>()
			.HasMany(m => m.MusicInstruments)
			.WithMany(i => i.Musicians);

			modelBuilder.Entity<Musician>()
			.HasMany(m => m.Genres)
			.WithMany(g => g.Musicians);

			modelBuilder.Entity<Group>()
			.HasMany(m => m.Genres)
			.WithMany(g => g.Groups);

			modelBuilder.Entity<MusicAlbum>()
			.HasMany(m => m.Genres)
			.WithMany(g => g.MusicAlbums);

			modelBuilder.Entity<Song>()
			.HasMany(m => m.Genres)
			.WithMany(g => g.Songs);
		}
	}
}
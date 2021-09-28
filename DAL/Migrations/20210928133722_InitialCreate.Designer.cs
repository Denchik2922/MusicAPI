﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210928133722_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GenreGroup", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "GroupsId");

                    b.HasIndex("GroupsId");

                    b.ToTable("GenreGroup");
                });

            modelBuilder.Entity("GenreMusicAlbum", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MusicAlbumsId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MusicAlbumsId");

                    b.HasIndex("MusicAlbumsId");

                    b.ToTable("GenreMusicAlbum");
                });

            modelBuilder.Entity("GenreMusician", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MusiciansId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MusiciansId");

                    b.HasIndex("MusiciansId");

                    b.ToTable("GenreMusician");
                });

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("SongsId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("GenreSong");
                });

            modelBuilder.Entity("Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Models.MusicAlbum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Length")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("MusicAlbums");
                });

            modelBuilder.Entity("Models.MusicInstrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MusicInstruments");
                });

            modelBuilder.Entity("Models.Musician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Musicians");
                });

            modelBuilder.Entity("Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Length")
                        .HasColumnType("time");

                    b.Property<int>("MusicAlbumId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MusicAlbumId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("MusicInstrumentMusician", b =>
                {
                    b.Property<int>("MusicInstrumentsId")
                        .HasColumnType("int");

                    b.Property<int>("MusiciansId")
                        .HasColumnType("int");

                    b.HasKey("MusicInstrumentsId", "MusiciansId");

                    b.HasIndex("MusiciansId");

                    b.ToTable("MusicInstrumentMusician");
                });

            modelBuilder.Entity("GenreGroup", b =>
                {
                    b.HasOne("Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMusicAlbum", b =>
                {
                    b.HasOne("Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.MusicAlbum", null)
                        .WithMany()
                        .HasForeignKey("MusicAlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMusician", b =>
                {
                    b.HasOne("Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Musician", null)
                        .WithMany()
                        .HasForeignKey("MusiciansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.HasOne("Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.MusicAlbum", b =>
                {
                    b.HasOne("Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Models.Musician", b =>
                {
                    b.HasOne("Models.Group", "Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Models.Song", b =>
                {
                    b.HasOne("Models.MusicAlbum", "MusicAlbum")
                        .WithMany("Songs")
                        .HasForeignKey("MusicAlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicAlbum");
                });

            modelBuilder.Entity("MusicInstrumentMusician", b =>
                {
                    b.HasOne("Models.MusicInstrument", null)
                        .WithMany()
                        .HasForeignKey("MusicInstrumentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Musician", null)
                        .WithMany()
                        .HasForeignKey("MusiciansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Group", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Models.MusicAlbum", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicInstruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicInstruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreGroup",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreGroup", x => new { x.GenresId, x.GroupsId });
                    table.ForeignKey(
                        name: "FK_GenreGroup_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreGroup_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicAlbums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<TimeSpan>(type: "time", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicAlbums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicAlbums_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musicians_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMusicAlbum",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MusicAlbumsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMusicAlbum", x => new { x.GenresId, x.MusicAlbumsId });
                    table.ForeignKey(
                        name: "FK_GenreMusicAlbum_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMusicAlbum_MusicAlbums_MusicAlbumsId",
                        column: x => x.MusicAlbumsId,
                        principalTable: "MusicAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<TimeSpan>(type: "time", nullable: false),
                    MusicAlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_MusicAlbums_MusicAlbumId",
                        column: x => x.MusicAlbumId,
                        principalTable: "MusicAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMusician",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MusiciansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMusician", x => new { x.GenresId, x.MusiciansId });
                    table.ForeignKey(
                        name: "FK_GenreMusician_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMusician_Musicians_MusiciansId",
                        column: x => x.MusiciansId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicInstrumentMusician",
                columns: table => new
                {
                    MusicInstrumentsId = table.Column<int>(type: "int", nullable: false),
                    MusiciansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicInstrumentMusician", x => new { x.MusicInstrumentsId, x.MusiciansId });
                    table.ForeignKey(
                        name: "FK_MusicInstrumentMusician_Musicians_MusiciansId",
                        column: x => x.MusiciansId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicInstrumentMusician_MusicInstruments_MusicInstrumentsId",
                        column: x => x.MusicInstrumentsId,
                        principalTable: "MusicInstruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    SongsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.GenresId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreGroup_GroupsId",
                table: "GenreGroup",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMusicAlbum_MusicAlbumsId",
                table: "GenreMusicAlbum",
                column: "MusicAlbumsId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMusician_MusiciansId",
                table: "GenreMusician",
                column: "MusiciansId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_SongsId",
                table: "GenreSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicAlbums_GroupId",
                table: "MusicAlbums",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Musicians_GroupId",
                table: "Musicians",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicInstrumentMusician_MusiciansId",
                table: "MusicInstrumentMusician",
                column: "MusiciansId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_MusicAlbumId",
                table: "Songs",
                column: "MusicAlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreGroup");

            migrationBuilder.DropTable(
                name: "GenreMusicAlbum");

            migrationBuilder.DropTable(
                name: "GenreMusician");

            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.DropTable(
                name: "MusicInstrumentMusician");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "MusicInstruments");

            migrationBuilder.DropTable(
                name: "MusicAlbums");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}

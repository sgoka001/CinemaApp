﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenreMovieVM",
                columns: table => new
                {
                    genreVM = table.Column<string>(nullable: false),
                    movieIdVM = table.Column<int>(nullable: false),
                    movies = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovieVM", x => x.genreVM);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Genre = table.Column<string>(maxLength: 50, nullable: false),
                    GenreMovieVMgenreVM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Genre);
                    table.ForeignKey(
                        name: "FK_Genres_GenreMovieVM_GenreMovieVMgenreVM",
                        column: x => x.GenreMovieVMgenreVM,
                        principalTable: "GenreMovieVM",
                        principalColumn: "genreVM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Released = table.Column<int>(nullable: false),
                    Movie_Genre = table.Column<string>(nullable: true),
                    Genre1 = table.Column<string>(nullable: true),
                    GenreMovieVMgenreVM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_Genre1",
                        column: x => x.Genre1,
                        principalTable: "Genres",
                        principalColumn: "Genre",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movies_GenreMovieVM_GenreMovieVMgenreVM",
                        column: x => x.GenreMovieVMgenreVM,
                        principalTable: "GenreMovieVM",
                        principalColumn: "genreVM",
                        onDelete: ReferentialAction.Restrict);
                });            

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreMovieVMgenreVM",
                table: "Genres",
                column: "GenreMovieVMgenreVM");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Genre1",
                table: "Movies",
                column: "Genre1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreMovieVMgenreVM",
                table: "Movies",
                column: "GenreMovieVMgenreVM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "GenreMovieVM");
        }
    }
}

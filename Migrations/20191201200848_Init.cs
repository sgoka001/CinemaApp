using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Genre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Genre);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Released = table.Column<int>(nullable: false),
                    Movie_Genre = table.Column<string>(nullable: true),
                    Genre1 = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.InsertData(
                table: "Genres",
                column: "Genre",
                values: new object[]
                {
                    "Sci-Fi",
                    "Comedy",
                    "Sad"
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Genre1", "Movie_Genre", "Name", "Released" },
                values: new object[,]
                {
                    { 1, null, "Sci-Fi", "Harry Potter 1", 2019 },
                    { 2, null, "Sci-Fi", "Harry Potter 2", 2018 },
                    { 3, null, "Sci-Fi", "Harry Potter 3", 2017 },
                    { 4, null, "Comedy", "Bruce Almighty", 2017 },
                    { 5, null, "Sad", "Titanic", 2017 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Genre1",
                table: "Movies",
                column: "Genre1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class actorMoviestbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actor_ActorsId",
                schema: "ordering",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genre_GenresId",
                schema: "ordering",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheater_Theater_TheatersId",
                schema: "ordering",
                table: "MovieTheater");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Theater",
                schema: "ordering",
                table: "Theater");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                schema: "ordering",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor",
                schema: "ordering",
                table: "Actor");

            migrationBuilder.RenameTable(
                name: "Theater",
                schema: "ordering",
                newName: "Theaters",
                newSchema: "ordering");

            migrationBuilder.RenameTable(
                name: "Genre",
                schema: "ordering",
                newName: "Genres",
                newSchema: "ordering");

            migrationBuilder.RenameTable(
                name: "Actor",
                schema: "ordering",
                newName: "Actors",
                newSchema: "ordering");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theaters",
                schema: "ordering",
                table: "Theaters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                schema: "ordering",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                schema: "ordering",
                table: "Actors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActorMovies",
                schema: "ordering",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovies", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_ActorMovies_Actors_ActorId",
                        column: x => x.ActorId,
                        principalSchema: "ordering",
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "ordering",
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_ActorId",
                schema: "ordering",
                table: "ActorMovies",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                schema: "ordering",
                table: "ActorMovie",
                column: "ActorsId",
                principalSchema: "ordering",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Genres_GenresId",
                schema: "ordering",
                table: "GenreMovie",
                column: "GenresId",
                principalSchema: "ordering",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheater_Theaters_TheatersId",
                schema: "ordering",
                table: "MovieTheater",
                column: "TheatersId",
                principalSchema: "ordering",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                schema: "ordering",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genres_GenresId",
                schema: "ordering",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheater_Theaters_TheatersId",
                schema: "ordering",
                table: "MovieTheater");

            migrationBuilder.DropTable(
                name: "ActorMovies",
                schema: "ordering");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Theaters",
                schema: "ordering",
                table: "Theaters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                schema: "ordering",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                schema: "ordering",
                table: "Actors");

            migrationBuilder.RenameTable(
                name: "Theaters",
                schema: "ordering",
                newName: "Theater",
                newSchema: "ordering");

            migrationBuilder.RenameTable(
                name: "Genres",
                schema: "ordering",
                newName: "Genre",
                newSchema: "ordering");

            migrationBuilder.RenameTable(
                name: "Actors",
                schema: "ordering",
                newName: "Actor",
                newSchema: "ordering");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theater",
                schema: "ordering",
                table: "Theater",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                schema: "ordering",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor",
                schema: "ordering",
                table: "Actor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actor_ActorsId",
                schema: "ordering",
                table: "ActorMovie",
                column: "ActorsId",
                principalSchema: "ordering",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Genre_GenresId",
                schema: "ordering",
                table: "GenreMovie",
                column: "GenresId",
                principalSchema: "ordering",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheater_Theater_TheatersId",
                schema: "ordering",
                table: "MovieTheater",
                column: "TheatersId",
                principalSchema: "ordering",
                principalTable: "Theater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

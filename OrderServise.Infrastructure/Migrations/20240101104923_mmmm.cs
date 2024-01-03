using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mmmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genres_GenresId",
                schema: "ordering",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Movies_MoviesId",
                schema: "ordering",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheater_Movies_MoviesId",
                schema: "ordering",
                table: "MovieTheater");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheater_Theaters_TheatersId",
                schema: "ordering",
                table: "MovieTheater");

            migrationBuilder.DropIndex(
                name: "IX_MovieTheater_TheatersId",
                schema: "ordering",
                table: "MovieTheater");

            migrationBuilder.DropIndex(
                name: "IX_GenreMovie_MoviesId",
                schema: "ordering",
                table: "GenreMovie");

            migrationBuilder.RenameColumn(
                name: "TheatersId",
                schema: "ordering",
                table: "MovieTheater",
                newName: "TheaterId");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                schema: "ordering",
                table: "MovieTheater",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                schema: "ordering",
                table: "GenreMovie",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                schema: "ordering",
                table: "GenreMovie",
                newName: "MovieId");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                schema: "ordering",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TheaterId",
                schema: "ordering",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                schema: "ordering",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_TheaterId",
                schema: "ordering",
                table: "Movies",
                column: "TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Movies_MovieId",
                schema: "ordering",
                table: "GenreMovie",
                column: "MovieId",
                principalSchema: "ordering",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                schema: "ordering",
                table: "Movies",
                column: "GenreId",
                principalSchema: "ordering",
                principalTable: "Genres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Theaters_TheaterId",
                schema: "ordering",
                table: "Movies",
                column: "TheaterId",
                principalSchema: "ordering",
                principalTable: "Theaters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheater_Movies_MovieId",
                schema: "ordering",
                table: "MovieTheater",
                column: "MovieId",
                principalSchema: "ordering",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Movies_MovieId",
                schema: "ordering",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Theaters_TheaterId",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheater_Movies_MovieId",
                schema: "ordering",
                table: "MovieTheater");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_TheaterId",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreId",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "TheaterId",
                schema: "ordering",
                table: "MovieTheater",
                newName: "TheatersId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                schema: "ordering",
                table: "MovieTheater",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                schema: "ordering",
                table: "GenreMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                schema: "ordering",
                table: "GenreMovie",
                newName: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheater_TheatersId",
                schema: "ordering",
                table: "MovieTheater",
                column: "TheatersId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesId",
                schema: "ordering",
                table: "GenreMovie",
                column: "MoviesId");

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
                name: "FK_GenreMovie_Movies_MoviesId",
                schema: "ordering",
                table: "GenreMovie",
                column: "MoviesId",
                principalSchema: "ordering",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheater_Movies_MoviesId",
                schema: "ordering",
                table: "MovieTheater",
                column: "MoviesId",
                principalSchema: "ordering",
                principalTable: "Movies",
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
    }
}

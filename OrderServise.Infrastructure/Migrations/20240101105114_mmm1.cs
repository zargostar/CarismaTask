using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mmm1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Theaters_TheaterId",
                schema: "ordering",
                table: "Movies");

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

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheater_TheaterId",
                schema: "ordering",
                table: "MovieTheater",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_GenreId",
                schema: "ordering",
                table: "GenreMovie",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Genres_GenreId",
                schema: "ordering",
                table: "GenreMovie",
                column: "GenreId",
                principalSchema: "ordering",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheater_Theaters_TheaterId",
                schema: "ordering",
                table: "MovieTheater",
                column: "TheaterId",
                principalSchema: "ordering",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genres_GenreId",
                schema: "ordering",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheater_Theaters_TheaterId",
                schema: "ordering",
                table: "MovieTheater");

            migrationBuilder.DropIndex(
                name: "IX_MovieTheater_TheaterId",
                schema: "ordering",
                table: "MovieTheater");

            migrationBuilder.DropIndex(
                name: "IX_GenreMovie_GenreId",
                schema: "ordering",
                table: "GenreMovie");

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
        }
    }
}

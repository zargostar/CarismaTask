using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class actorMoviestb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                schema: "ordering",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MoviesId",
                schema: "ordering",
                table: "ActorMovie");

            migrationBuilder.DropTable(
                name: "ActorMovies",
                schema: "ordering");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                schema: "ordering",
                table: "ActorMovie",
                newName: "ActorId");

            migrationBuilder.RenameColumn(
                name: "ActorsId",
                schema: "ordering",
                table: "ActorMovie",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MoviesId",
                schema: "ordering",
                table: "ActorMovie",
                newName: "IX_ActorMovie_ActorId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "ordering",
                table: "ActorMovie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                schema: "ordering",
                table: "ActorMovie",
                column: "ActorId",
                principalSchema: "ordering",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                schema: "ordering",
                table: "ActorMovie",
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
                name: "FK_ActorMovie_Actors_ActorId",
                schema: "ordering",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                schema: "ordering",
                table: "ActorMovie");

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "ordering",
                table: "ActorMovie");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                schema: "ordering",
                table: "ActorMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                schema: "ordering",
                table: "ActorMovie",
                newName: "ActorsId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_ActorId",
                schema: "ordering",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MoviesId");

            migrationBuilder.CreateTable(
                name: "ActorMovies",
                schema: "ordering",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
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
                name: "FK_ActorMovie_Movies_MoviesId",
                schema: "ordering",
                table: "ActorMovie",
                column: "MoviesId",
                principalSchema: "ordering",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

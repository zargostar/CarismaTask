using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class identityAdded0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalCode",
                schema: "ordering",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PersonnelCode",
                schema: "ordering",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                schema: "ordering",
                table: "AspNetUsers",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "ordering",
                table: "AspNetUsers",
                newName: "PersonnelCode");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "ordering",
                table: "AspNetUsers",
                newName: "Fullname");

            migrationBuilder.AddColumn<int>(
                name: "NationalCode",
                schema: "ordering",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

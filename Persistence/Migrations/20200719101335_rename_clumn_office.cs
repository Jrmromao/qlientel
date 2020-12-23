using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class rename_clumn_office : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "t_offices");

            migrationBuilder.AddColumn<string>(
                name: "_Code",
                table: "t_offices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_Code",
                table: "t_offices");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "t_offices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
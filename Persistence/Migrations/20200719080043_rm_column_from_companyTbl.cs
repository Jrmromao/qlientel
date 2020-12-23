using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class rm_column_from_companyTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FiscalNumber",
                table: "t_companies");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "t_companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FiscalNumber",
                table: "t_companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "t_companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
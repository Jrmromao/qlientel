using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updade_fiscalNumber_to_company_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FicalNumber",
                table: "t_companies");

            migrationBuilder.AddColumn<string>(
                name: "FiscalNumber",
                table: "t_companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FiscalNumber",
                table: "t_companies");

            migrationBuilder.AddColumn<string>(
                name: "FicalNumber",
                table: "t_companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
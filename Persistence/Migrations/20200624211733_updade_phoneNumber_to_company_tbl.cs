using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updade_phoneNumber_to_company_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNummber",
                table: "t_companies");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "t_companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "t_companies");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNummber",
                table: "t_companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
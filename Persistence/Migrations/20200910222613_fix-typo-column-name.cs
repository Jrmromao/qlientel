using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class fixtypocolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnualLeaves",
                table: "t_schedulePolicy");

            migrationBuilder.AddColumn<string>(
                name: "AnnualLeaves",
                table: "t_schedulePolicy",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualLeaves",
                table: "t_schedulePolicy");

            migrationBuilder.AddColumn<string>(
                name: "AnualLeaves",
                table: "t_schedulePolicy",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

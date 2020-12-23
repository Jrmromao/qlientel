using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updatedatabasetbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnualLeaves",
                table: "t_schedulePolicy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentTerm",
                table: "t_employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "t_employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShedulePolicy",
                table: "t_employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnualLeaves",
                table: "t_schedulePolicy");

            migrationBuilder.DropColumn(
                name: "EmploymentTerm",
                table: "t_employees");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "t_employees");

            migrationBuilder.DropColumn(
                name: "ShedulePolicy",
                table: "t_employees");
        }
    }
}

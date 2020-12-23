using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updatetblrel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t_leaves_EmployeeId",
                table: "t_leaves");

            migrationBuilder.CreateIndex(
                name: "IX_t_leaves_EmployeeId",
                table: "t_leaves",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t_leaves_EmployeeId",
                table: "t_leaves");

            migrationBuilder.CreateIndex(
                name: "IX_t_leaves_EmployeeId",
                table: "t_leaves",
                column: "EmployeeId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addnavigationproptoemployeeDetailsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeeDetailsId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeDetailsId",
                table: "AspNetUsers",
                column: "EmployeeDetailsId",
                unique: true,
                filter: "[EmployeeDetailsId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeeDetailsId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeDetailsId",
                table: "AspNetUsers",
                column: "EmployeeDetailsId");
        }
    }
}
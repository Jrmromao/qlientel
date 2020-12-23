using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addrelationsemployeedepartmentofficecompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_department_AspNetUsers_ManagerId",
                table: "t_department");

            migrationBuilder.DropIndex(
                name: "IX_t_department_ManagerId",
                table: "t_department");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "t_department");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "t_department",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_department_ManagerId",
                table: "t_department",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_department_AspNetUsers_ManagerId",
                table: "t_department",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
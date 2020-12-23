using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addclmndepartmentmanager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId1",
                table: "t_departmentManager",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "t_department",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_departmentManager_DepartmentId",
                table: "t_departmentManager",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_t_departmentManager_ManagerId1",
                table: "t_departmentManager",
                column: "ManagerId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_t_departmentManager_AspNetUsers_ManagerId1",
                table: "t_departmentManager",
                column: "ManagerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_t_departmentManager_t_department_DepartmentId",
                table: "t_departmentManager",
                column: "DepartmentId",
                principalTable: "t_department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_department_AspNetUsers_ManagerId",
                table: "t_department");

            migrationBuilder.DropForeignKey(
                name: "FK_t_departmentManager_AspNetUsers_ManagerId1",
                table: "t_departmentManager");

            migrationBuilder.DropForeignKey(
                name: "FK_t_departmentManager_t_department_DepartmentId",
                table: "t_departmentManager");

            migrationBuilder.DropIndex(
                name: "IX_t_departmentManager_DepartmentId",
                table: "t_departmentManager");

            migrationBuilder.DropIndex(
                name: "IX_t_departmentManager_ManagerId1",
                table: "t_departmentManager");

            migrationBuilder.DropIndex(
                name: "IX_t_department_ManagerId",
                table: "t_department");

            migrationBuilder.DropColumn(
                name: "ManagerId1",
                table: "t_departmentManager");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "t_department");
        }
    }
}
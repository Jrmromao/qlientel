using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class rmclmndepartmentmanager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_departmentManager_AspNetUsers_ManagerId1",
                table: "t_departmentManager");

            migrationBuilder.DropIndex(
                name: "IX_t_departmentManager_ManagerId1",
                table: "t_departmentManager");

            migrationBuilder.DropColumn(
                name: "ManagerId1",
                table: "t_departmentManager");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "t_departmentManager",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_t_departmentManager_ManagerId",
                table: "t_departmentManager",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_departmentManager_AspNetUsers_ManagerId",
                table: "t_departmentManager",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_departmentManager_AspNetUsers_ManagerId",
                table: "t_departmentManager");

            migrationBuilder.DropIndex(
                name: "IX_t_departmentManager_ManagerId",
                table: "t_departmentManager");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "t_departmentManager",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerId1",
                table: "t_departmentManager",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_departmentManager_ManagerId1",
                table: "t_departmentManager",
                column: "ManagerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_t_departmentManager_AspNetUsers_ManagerId1",
                table: "t_departmentManager",
                column: "ManagerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
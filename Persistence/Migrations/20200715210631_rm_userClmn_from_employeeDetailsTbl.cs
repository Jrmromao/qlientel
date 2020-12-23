using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class rm_userClmn_from_employeeDetailsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeeDetailsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "t_employees");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeDetailsId",
                table: "AspNetUsers",
                column: "EmployeeDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeeDetailsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "t_employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeDetailsId",
                table: "AspNetUsers",
                column: "EmployeeDetailsId",
                unique: true,
                filter: "[EmployeeDetailsId] IS NOT NULL");
        }
    }
}
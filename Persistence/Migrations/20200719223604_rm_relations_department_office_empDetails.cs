using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class rm_relations_department_office_empDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_employees_t_offices_OfficeId",
                table: "t_employees");

            migrationBuilder.DropIndex(
                name: "IX_t_employees_OfficeId",
                table: "t_employees");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "t_employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "t_employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_employees_OfficeId",
                table: "t_employees",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_employees_t_offices_OfficeId",
                table: "t_employees",
                column: "OfficeId",
                principalTable: "t_offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
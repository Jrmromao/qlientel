using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class addofficedepartmentrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_department_t_companies_CompanyId",
                table: "t_department");

            migrationBuilder.DropIndex(
                name: "IX_t_department_CompanyId",
                table: "t_department");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "t_department");

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "t_department",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_department_OfficeId",
                table: "t_department",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_department_t_offices_OfficeId",
                table: "t_department",
                column: "OfficeId",
                principalTable: "t_offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_department_t_offices_OfficeId",
                table: "t_department");

            migrationBuilder.DropIndex(
                name: "IX_t_department_OfficeId",
                table: "t_department");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "t_department");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "t_department",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_department_CompanyId",
                table: "t_department",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_department_t_companies_CompanyId",
                table: "t_department",
                column: "CompanyId",
                principalTable: "t_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
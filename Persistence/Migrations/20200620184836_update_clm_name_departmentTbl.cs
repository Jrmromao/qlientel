using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class update_clm_name_departmentTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_department_t_offices_OfficeId",
                table: "t_department");

            migrationBuilder.DropColumn(
                name: "CompanyLocationId",
                table: "t_department");

            migrationBuilder.AlterColumn<Guid>(
                name: "OfficeId",
                table: "t_department",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_t_department_t_offices_OfficeId",
                table: "t_department",
                column: "OfficeId",
                principalTable: "t_offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_department_t_offices_OfficeId",
                table: "t_department");

            migrationBuilder.AlterColumn<Guid>(
                name: "OfficeId",
                table: "t_department",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyLocationId",
                table: "t_department",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_t_department_t_offices_OfficeId",
                table: "t_department",
                column: "OfficeId",
                principalTable: "t_offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
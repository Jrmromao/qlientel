using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class add_departmentManagerTBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_offices_t_address_AddressId",
                table: "t_offices");

            migrationBuilder.DropForeignKey(
                name: "FK_t_offices_t_companies_CompanyId",
                table: "t_offices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_offices",
                table: "t_offices");

            migrationBuilder.RenameTable(
                name: "t_offices",
                newName: "Office");

            migrationBuilder.RenameIndex(
                name: "IX_t_offices_CompanyId",
                table: "Office",
                newName: "IX_Office_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_t_offices_AddressId",
                table: "Office",
                newName: "IX_Office_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Office",
                table: "Office",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "t_departmentManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_departmentManager", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Office_t_address_AddressId",
                table: "Office",
                column: "AddressId",
                principalTable: "t_address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Office_t_companies_CompanyId",
                table: "Office",
                column: "CompanyId",
                principalTable: "t_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Office_t_address_AddressId",
                table: "Office");

            migrationBuilder.DropForeignKey(
                name: "FK_Office_t_companies_CompanyId",
                table: "Office");

            migrationBuilder.DropTable(
                name: "t_departmentManager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Office",
                table: "Office");

            migrationBuilder.RenameTable(
                name: "Office",
                newName: "t_offices");

            migrationBuilder.RenameIndex(
                name: "IX_Office_CompanyId",
                table: "t_offices",
                newName: "IX_t_offices_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Office_AddressId",
                table: "t_offices",
                newName: "IX_t_offices_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_offices",
                table: "t_offices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_offices_t_address_AddressId",
                table: "t_offices",
                column: "AddressId",
                principalTable: "t_address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_t_offices_t_companies_CompanyId",
                table: "t_offices",
                column: "CompanyId",
                principalTable: "t_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
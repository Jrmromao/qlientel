using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class restoreDBStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_department_AspNetUsers_ManagerId",
                table: "t_department");

            migrationBuilder.DropForeignKey(
                name: "FK_t_department_t_offices_OfficeId",
                table: "t_department");

            migrationBuilder.DropTable(
                name: "t_departmentManager");

            migrationBuilder.DropIndex(
                name: "IX_t_offices_CompanyId",
                table: "t_offices");

            migrationBuilder.DropIndex(
                name: "IX_t_department_ManagerId",
                table: "t_department");

            migrationBuilder.DropIndex(
                name: "IX_t_department_OfficeId",
                table: "t_department");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "t_offices");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "t_department");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "t_department");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "t_offices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "t_department",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_offices_AddressId",
                table: "t_offices",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_t_offices_CompanyId",
                table: "t_offices",
                column: "CompanyId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_t_offices_t_address_AddressId",
                table: "t_offices",
                column: "AddressId",
                principalTable: "t_address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_department_t_companies_CompanyId",
                table: "t_department");

            migrationBuilder.DropForeignKey(
                name: "FK_t_offices_t_address_AddressId",
                table: "t_offices");

            migrationBuilder.DropIndex(
                name: "IX_t_offices_AddressId",
                table: "t_offices");

            migrationBuilder.DropIndex(
                name: "IX_t_offices_CompanyId",
                table: "t_offices");

            migrationBuilder.DropIndex(
                name: "IX_t_department_CompanyId",
                table: "t_department");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "t_offices");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "t_department");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "t_offices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "t_department",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "t_department",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "t_departmentManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_departmentManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_departmentManager_AspNetUsers_ManagerId1",
                        column: x => x.ManagerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_departmentManager_t_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "t_department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_offices_CompanyId",
                table: "t_offices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_t_department_ManagerId",
                table: "t_department",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_t_department_OfficeId",
                table: "t_department",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_t_departmentManager_DepartmentId",
                table: "t_departmentManager",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_t_departmentManager_ManagerId1",
                table: "t_departmentManager",
                column: "ManagerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_t_department_AspNetUsers_ManagerId",
                table: "t_department",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_t_department_t_offices_OfficeId",
                table: "t_department",
                column: "OfficeId",
                principalTable: "t_offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
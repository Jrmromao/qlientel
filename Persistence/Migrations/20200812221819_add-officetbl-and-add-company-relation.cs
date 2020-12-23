using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class addofficetblandaddcompanyrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Office_t_address_AddressId",
                table: "Office");

            migrationBuilder.DropForeignKey(
                name: "FK_Office_t_companies_CompanyId",
                table: "Office");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Office",
                table: "Office");

            migrationBuilder.DropIndex(
                name: "IX_Office_CompanyId",
                table: "Office");

            migrationBuilder.RenameTable(
                name: "Office",
                newName: "t_offices");

            migrationBuilder.RenameIndex(
                name: "IX_Office_AddressId",
                table: "t_offices",
                newName: "IX_t_offices_AddressId");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_offices",
                table: "t_offices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_t_offices_CompanyId",
                table: "t_offices",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_t_department_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "t_department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_t_department_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_t_offices_t_address_AddressId",
                table: "t_offices");

            migrationBuilder.DropForeignKey(
                name: "FK_t_offices_t_companies_CompanyId",
                table: "t_offices");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_offices",
                table: "t_offices");

            migrationBuilder.DropIndex(
                name: "IX_t_offices_CompanyId",
                table: "t_offices");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "t_offices",
                newName: "Office");

            migrationBuilder.RenameIndex(
                name: "IX_t_offices_AddressId",
                table: "Office",
                newName: "IX_Office_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Office",
                table: "Office",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Office_CompanyId",
                table: "Office",
                column: "CompanyId",
                unique: true);

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
    }
}
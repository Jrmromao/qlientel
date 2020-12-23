using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class rm_officeAddressTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_offices_t_officeAddress_AddressId",
                table: "t_offices");

            migrationBuilder.DropTable(
                name: "t_officeAddress");

            migrationBuilder.DropIndex(
                name: "IX_t_offices_AddressId",
                table: "t_offices");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "t_offices");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "t_offices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "t_officeAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_officeAddress", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_offices_AddressId",
                table: "t_offices",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_offices_t_officeAddress_AddressId",
                table: "t_offices",
                column: "AddressId",
                principalTable: "t_officeAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
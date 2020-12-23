using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class addofficeaddresstbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_offices_t_address_AddressId",
                table: "t_offices");

            migrationBuilder.CreateTable(
                name: "t_officeAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_officeAddress", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_t_offices_t_officeAddress_AddressId",
                table: "t_offices",
                column: "AddressId",
                principalTable: "t_officeAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_offices_t_officeAddress_AddressId",
                table: "t_offices");

            migrationBuilder.DropTable(
                name: "t_officeAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_t_offices_t_address_AddressId",
                table: "t_offices",
                column: "AddressId",
                principalTable: "t_address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addcustomerTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "t_documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "t_customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointOfContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_customers_t_address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "t_address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_customers_t_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "t_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_documents_CustomerId",
                table: "t_documents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_t_customers_AddressId",
                table: "t_customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_t_customers_CompanyId",
                table: "t_customers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_documents_t_customers_CustomerId",
                table: "t_documents",
                column: "CustomerId",
                principalTable: "t_customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_documents_t_customers_CustomerId",
                table: "t_documents");

            migrationBuilder.DropTable(
                name: "t_customers");

            migrationBuilder.DropIndex(
                name: "IX_t_documents_CustomerId",
                table: "t_documents");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "t_documents");
        }
    }
}

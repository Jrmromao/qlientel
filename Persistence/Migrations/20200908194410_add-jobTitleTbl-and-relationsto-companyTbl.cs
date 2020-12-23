using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addjobTitleTblandrelationstocompanyTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t_schedulePolicy_CompanyId",
                table: "t_schedulePolicy");

            migrationBuilder.AddColumn<Guid>(
                name: "JboTitleId",
                table: "t_companies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "t_jobTitle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_jobTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_jobTitle_t_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "t_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_schedulePolicy_CompanyId",
                table: "t_schedulePolicy",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_jobTitle_CompanyId",
                table: "t_jobTitle",
                column: "CompanyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_jobTitle");

            migrationBuilder.DropIndex(
                name: "IX_t_schedulePolicy_CompanyId",
                table: "t_schedulePolicy");

            migrationBuilder.DropColumn(
                name: "JboTitleId",
                table: "t_companies");

            migrationBuilder.CreateIndex(
                name: "IX_t_schedulePolicy_CompanyId",
                table: "t_schedulePolicy",
                column: "CompanyId");
        }
    }
}

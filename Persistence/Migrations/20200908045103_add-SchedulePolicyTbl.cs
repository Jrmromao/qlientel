using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addSchedulePolicyTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_schedulePolicy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekHours = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_schedulePolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_schedulePolicy_t_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "t_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_schedulePolicy_CompanyId",
                table: "t_schedulePolicy",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_schedulePolicy");
        }
    }
}

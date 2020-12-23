using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updateclmnnameandrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t_jobTitle_CompanyId",
                table: "t_jobTitle");

            migrationBuilder.DropColumn(
                name: "JboTitleId",
                table: "t_companies");

            migrationBuilder.AddColumn<Guid>(
                name: "JobTitleId",
                table: "t_companies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_t_jobTitle_CompanyId",
                table: "t_jobTitle",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t_jobTitle_CompanyId",
                table: "t_jobTitle");

            migrationBuilder.DropColumn(
                name: "JobTitleId",
                table: "t_companies");

            migrationBuilder.AddColumn<Guid>(
                name: "JboTitleId",
                table: "t_companies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_t_jobTitle_CompanyId",
                table: "t_jobTitle",
                column: "CompanyId",
                unique: true);
        }
    }
}

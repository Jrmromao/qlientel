using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class changeClmnName_startingDate_to_SDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingDate",
                table: "t_employees");

            migrationBuilder.AddColumn<DateTime>(
                name: "SDate",
                table: "t_employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SDate",
                table: "t_employees");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                table: "t_employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
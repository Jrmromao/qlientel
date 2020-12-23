using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addtimeStampclmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "DateCreated",
                table: "t_offices",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DateCreated",
                table: "t_employees",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DateCreated",
                table: "t_emergencyContact",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DateCreated",
                table: "t_documents",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DateCreated",
                table: "t_departmentManager",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DateCreated",
                table: "t_department",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DateCreated",
                table: "t_companies",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DateCreated",
                table: "t_bankDetails",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DateCreated",
                table: "t_address",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "t_offices");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "t_employees");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "t_emergencyContact");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "t_documents");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "t_departmentManager");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "t_department");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "t_companies");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "t_bankDetails");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "t_address");
        }
    }
}
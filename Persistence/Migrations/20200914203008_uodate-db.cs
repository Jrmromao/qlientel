using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class uodatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventsId",
                table: "t_employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeaveRequestId",
                table: "t_employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "t_events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_events_t_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "t_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_leaveRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    SentToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_leaveRequest", x => x.Id);
                    table.CheckConstraint("CK_t_leaveRequest_Status_Enum_Constraint", "[Status] IN(0, 1, 2)");
                    table.ForeignKey(
                        name: "FK_t_leaveRequest_t_employees_SentToId",
                        column: x => x.SentToId,
                        principalTable: "t_employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_leaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TakenToDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_leaves_t_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "t_employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_employees_EventsId",
                table: "t_employees",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_t_employees_LeaveRequestId",
                table: "t_employees",
                column: "LeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_t_events_CompanyId",
                table: "t_events",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_t_leaveRequest_SentToId",
                table: "t_leaveRequest",
                column: "SentToId");

            migrationBuilder.CreateIndex(
                name: "IX_t_leaves_EmployeeId",
                table: "t_leaves",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_employees_t_events_EventsId",
                table: "t_employees",
                column: "EventsId",
                principalTable: "t_events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_t_employees_t_leaveRequest_LeaveRequestId",
                table: "t_employees",
                column: "LeaveRequestId",
                principalTable: "t_leaveRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_employees_t_events_EventsId",
                table: "t_employees");

            migrationBuilder.DropForeignKey(
                name: "FK_t_employees_t_leaveRequest_LeaveRequestId",
                table: "t_employees");

            migrationBuilder.DropTable(
                name: "t_events");

            migrationBuilder.DropTable(
                name: "t_leaveRequest");

            migrationBuilder.DropTable(
                name: "t_leaves");

            migrationBuilder.DropIndex(
                name: "IX_t_employees_EventsId",
                table: "t_employees");

            migrationBuilder.DropIndex(
                name: "IX_t_employees_LeaveRequestId",
                table: "t_employees");

            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "t_employees");

            migrationBuilder.DropColumn(
                name: "LeaveRequestId",
                table: "t_employees");
        }
    }
}

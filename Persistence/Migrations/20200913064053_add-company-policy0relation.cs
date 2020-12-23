using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addcompanypolicy0relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t_schedulePolicy_CompanyId",
                table: "t_schedulePolicy");

            migrationBuilder.CreateIndex(
                name: "IX_t_schedulePolicy_CompanyId",
                table: "t_schedulePolicy",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t_schedulePolicy_CompanyId",
                table: "t_schedulePolicy");

            migrationBuilder.CreateIndex(
                name: "IX_t_schedulePolicy_CompanyId",
                table: "t_schedulePolicy",
                column: "CompanyId",
                unique: true);
        }
    }
}

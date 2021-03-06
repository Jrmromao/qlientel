﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
    public partial class add_navigation_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_employees_AspNetUsers_AppUserId",
                table: "t_employees");

            migrationBuilder.DropIndex(
                name: "IX_t_employees_AppUserId",
                table: "t_employees");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "t_employees");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeDetailsId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeDetailsId",
                table: "AspNetUsers",
                column: "EmployeeDetailsId",
                unique: true,
                filter: "[EmployeeDetailsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_t_employees_EmployeeDetailsId",
                table: "AspNetUsers",
                column: "EmployeeDetailsId",
                principalTable: "t_employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_t_employees_EmployeeDetailsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeeDetailsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeDetailsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "t_employees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_employees_AppUserId",
                table: "t_employees",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_employees_AspNetUsers_AppUserId",
                table: "t_employees",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
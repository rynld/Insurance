using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Insurance.Migrations
{
    public partial class seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PlanTypes_PlanTypeId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "PlanTypeId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PlanTypes_PlanTypeId",
                table: "Customers",
                column: "PlanTypeId",
                principalTable: "PlanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PlanTypes_PlanTypeId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "PlanTypeId",
                table: "Customers",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PlanTypes_PlanTypeId",
                table: "Customers",
                column: "PlanTypeId",
                principalTable: "PlanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

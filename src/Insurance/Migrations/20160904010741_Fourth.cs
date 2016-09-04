using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Insurance.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PlanType",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PlanType",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanTypeId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanTypeId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId",
                table: "Transactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PlanTypeId",
                table: "Transactions",
                column: "PlanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PlanTypeId",
                table: "Customers",
                column: "PlanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PlanTypes_PlanTypeId",
                table: "Customers",
                column: "PlanTypeId",
                principalTable: "PlanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_ClientId",
                table: "Transactions",
                column: "ClientId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PlanTypes_PlanTypeId",
                table: "Transactions",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_ClientId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PlanTypes_PlanTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ClientId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PlanTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PlanTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PlanTypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PlanTypeId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                table: "Customers",
                nullable: true);
        }
    }
}

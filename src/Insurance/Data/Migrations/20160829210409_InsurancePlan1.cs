using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Insurance.Data.Migrations
{
    public partial class InsurancePlan1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "InsuranceType",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "InsuranceNameId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsuranceTypeId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_InsuranceNameId",
                table: "Customers",
                column: "InsuranceNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_InsuranceTypeId",
                table: "Customers",
                column: "InsuranceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_InsuranceCompanies_InsuranceNameId",
                table: "Customers",
                column: "InsuranceNameId",
                principalTable: "InsuranceCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PlanTypes_InsuranceTypeId",
                table: "Customers",
                column: "InsuranceTypeId",
                principalTable: "PlanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_InsuranceCompanies_InsuranceNameId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PlanTypes_InsuranceTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_InsuranceNameId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_InsuranceTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "InsuranceNameId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "InsuranceTypeId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "InsuranceName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceType",
                table: "Customers",
                nullable: true);
        }
    }
}

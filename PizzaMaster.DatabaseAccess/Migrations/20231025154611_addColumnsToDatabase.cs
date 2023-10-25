﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaster.Data.Migrations
{
    public partial class addColumnsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Restorans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Restorans",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Restorans");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Restorans");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagement.Persistence.Migrations
{
    public partial class updateApartmentPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEntry",
                table: "ApartmentPerson",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfExit",
                table: "ApartmentPerson",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfEntry",
                table: "ApartmentPerson");

            migrationBuilder.DropColumn(
                name: "DateOfExit",
                table: "ApartmentPerson");
        }
    }
}

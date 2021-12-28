using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagement.Persistence.Migrations
{
    public partial class SiteTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SiteId",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SiteId",
                table: "Blocks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SiteId",
                table: "Apartments",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SiteName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CellPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Province = table.Column<string>(type: "TEXT", nullable: true),
                    District = table.Column<string>(type: "TEXT", nullable: true),
                    BlockCount = table.Column<int>(type: "INTEGER", nullable: true),
                    ApartmentCount = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SiteId",
                table: "Persons",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_SiteId",
                table: "Blocks",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_SiteId",
                table: "Apartments",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Sites_SiteId",
                table: "Apartments",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_Sites_SiteId",
                table: "Blocks",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Sites_SiteId",
                table: "Persons",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Sites_SiteId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Sites_SiteId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Sites_SiteId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Persons_SiteId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_SiteId",
                table: "Blocks");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_SiteId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Apartments");
        }
    }
}

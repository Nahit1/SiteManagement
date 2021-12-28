using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagement.Persistence.Migrations
{
    public partial class addColumnApartmentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ApartmentTypes",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ApartmentTypes");
        }
    }
}

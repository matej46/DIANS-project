using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelMK.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Lat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Lon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name_MK = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Municipality_EN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Municipality_MK = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}

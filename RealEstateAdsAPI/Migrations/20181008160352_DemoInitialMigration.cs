using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateAdsAPI.Migrations
{
    public partial class DemoInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Demo");

            migrationBuilder.CreateTable(
                name: "Flats",
                schema: "Demo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Floor = table.Column<int>(nullable: false),
                    Rooms = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlatAds",
                schema: "Demo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    FlatId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlatAds_Flats_FlatId",
                        column: x => x.FlatId,
                        principalSchema: "Demo",
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlatAds_FlatId",
                schema: "Demo",
                table: "FlatAds",
                column: "FlatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlatAds",
                schema: "Demo");

            migrationBuilder.DropTable(
                name: "Flats",
                schema: "Demo");
        }
    }
}

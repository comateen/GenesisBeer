using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _01_DB.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brewery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brewery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wholesaler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesaler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Degree = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    BreweryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beer_Brewery_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Brewery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockBeerWholesaler",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    WholesalerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBeerWholesaler", x => new { x.BeerId, x.WholesalerId });
                    table.ForeignKey(
                        name: "FK_StockBeerWholesaler_Beer_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockBeerWholesaler_Wholesaler_WholesalerId",
                        column: x => x.WholesalerId,
                        principalTable: "Wholesaler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brewery",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bosteels" },
                    { 2, "Abbaye St-Sixtus" },
                    { 3, "Abbaye de Grimbergen" }
                });

            migrationBuilder.InsertData(
                table: "Wholesaler",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "GeneDrinks" },
                    { 2, "TangissartShop" }
                });

            migrationBuilder.InsertData(
                table: "Beer",
                columns: new[] { "Id", "BreweryId", "Degree", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 84f, "Triple Karmeliet", 27f },
                    { 2, 1, 84f, "Kwak", 245f },
                    { 3, 2, 58f, "WestVletteren Blonde", 8f },
                    { 4, 2, 8f, "WestVletteren 8", 11f },
                    { 5, 2, 12f, "WestVletteren 12", 14f },
                    { 6, 3, 67f, "Grimbergen Blonde", 22f },
                    { 7, 3, 65f, "Grimbergen Double", 22f },
                    { 8, 3, 8f, "Grimbergen Triple", 23f }
                });

            migrationBuilder.InsertData(
                table: "StockBeerWholesaler",
                columns: new[] { "BeerId", "WholesalerId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 500 },
                    { 2, 1, 300 },
                    { 3, 2, 200 },
                    { 4, 2, 200 },
                    { 5, 2, 200 },
                    { 6, 1, 200 },
                    { 7, 1, 200 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beer_BreweryId",
                table: "Beer",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_StockBeerWholesaler_WholesalerId",
                table: "StockBeerWholesaler",
                column: "WholesalerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockBeerWholesaler");

            migrationBuilder.DropTable(
                name: "Beer");

            migrationBuilder.DropTable(
                name: "Wholesaler");

            migrationBuilder.DropTable(
                name: "Brewery");
        }
    }
}

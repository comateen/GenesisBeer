using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_DB.Migrations
{
    /// <inheritdoc />
    public partial class add_estimate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estimate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WholesalerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeerEstimate",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    EstimateId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerEstimate", x => new { x.BeerId, x.EstimateId });
                    table.ForeignKey(
                        name: "FK_BeerEstimate_Estimate_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerEstimate_EstimateId",
                table: "BeerEstimate",
                column: "EstimateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerEstimate");

            migrationBuilder.DropTable(
                name: "Estimate");
        }
    }
}

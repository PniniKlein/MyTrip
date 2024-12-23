using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trips.Data.Migrations
{
    public partial class secondRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attractionToTrips");

            migrationBuilder.RenameColumn(
                name: "GuideCode",
                table: "trips",
                newName: "GuideId");

            migrationBuilder.RenameColumn(
                name: "UserCode",
                table: "orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TripCode",
                table: "orders",
                newName: "TripId");

            migrationBuilder.CreateTable(
                name: "AttractionTrip",
                columns: table => new
                {
                    attractionsId = table.Column<int>(type: "int", nullable: false),
                    tripsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionTrip", x => new { x.attractionsId, x.tripsId });
                    table.ForeignKey(
                        name: "FK_AttractionTrip_attractions_attractionsId",
                        column: x => x.attractionsId,
                        principalTable: "attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttractionTrip_trips_tripsId",
                        column: x => x.tripsId,
                        principalTable: "trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trips_GuideId",
                table: "trips",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_TripId",
                table: "orders",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId",
                table: "orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttractionTrip_tripsId",
                table: "AttractionTrip",
                column: "tripsId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_trips_TripId",
                table: "orders",
                column: "TripId",
                principalTable: "trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_guides_GuideId",
                table: "trips",
                column: "GuideId",
                principalTable: "guides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_trips_TripId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_UserId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_guides_GuideId",
                table: "trips");

            migrationBuilder.DropTable(
                name: "AttractionTrip");

            migrationBuilder.DropIndex(
                name: "IX_trips_GuideId",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_orders_TripId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_UserId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "GuideId",
                table: "trips",
                newName: "GuideCode");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "orders",
                newName: "UserCode");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "orders",
                newName: "TripCode");

            migrationBuilder.CreateTable(
                name: "attractionToTrips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttractionCode = table.Column<int>(type: "int", nullable: false),
                    TripCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attractionToTrips", x => x.Id);
                });
        }
    }
}

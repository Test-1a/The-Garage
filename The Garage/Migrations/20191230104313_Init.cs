using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Garage.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfVehicle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNr = table.Column<string>(nullable: false),
                    TimeOfParking = table.Column<DateTime>(nullable: false),
                    NumnOfWheels = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Jeon", "James" },
                    { 2, "Rod", "Rodsson" },
                    { 3, "Mikael", "Mickesson" },
                    { 4, "Moha", "Mohammedsson" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "TypeOfVehicle" },
                values: new object[,]
                {
                    { 1, "Car" },
                    { 2, "Bus" },
                    { 3, "Boat" },
                    { 4, "Airplane" },
                    { 5, "Motorcycle" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Color", "MemberId", "Model", "NumnOfWheels", "RegNr", "TimeOfParking", "TypeId" },
                values: new object[,]
                {
                    { 1, "Volvo", "Blue", 1, "Sports", 4, "ABCG123", new DateTime(2019, 12, 30, 11, 43, 13, 85, DateTimeKind.Local).AddTicks(4504), 1 },
                    { 2, "Volvo", "Blue", 2, "Sports", 4, "ABCG123", new DateTime(2019, 12, 30, 11, 43, 13, 88, DateTimeKind.Local).AddTicks(3491), 3 },
                    { 3, "BMW", "Green", 2, "Business", 4, "ASD678", new DateTime(2019, 12, 30, 11, 43, 13, 88, DateTimeKind.Local).AddTicks(3557), 3 },
                    { 4, "Airbus", "Black", 3, "Travel", 4, "ABC456", new DateTime(2019, 12, 30, 11, 43, 13, 88, DateTimeKind.Local).AddTicks(3564), 4 },
                    { 5, "Volvo", "Blue", 4, "Sedan", 4, "XXX789", new DateTime(2019, 12, 30, 11, 43, 13, 88, DateTimeKind.Local).AddTicks(3637), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MemberId",
                table: "Vehicles",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TypeId",
                table: "Vehicles",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarFleetIO.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localizations",
                columns: table => new
                {
                    LocalizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizations", x => x.LocalizationId);
                });

            migrationBuilder.CreateTable(
                name: "AdministrationUser",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SecurityNumber = table.Column<long>(type: "bigint", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Office = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrationUser", x => x.Username);
                    table.ForeignKey(
                        name: "FK_AdministrationUser_Localizations_Office",
                        column: x => x.Office,
                        principalTable: "Localizations",
                        principalColumn: "LocalizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                    {
                        Username = table.Column<string>(type: "text", nullable: false),
                        IsActive = table.Column<bool>(type: "boolean", nullable: false),
                        Office = table.Column<Guid>(type: "uuid", nullable: false),
                        SecurityNumber = table.Column<long>(type: "bigint", nullable: false),
                        BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                        Gender = table.Column<string>(type: "text", nullable: false),
                        HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                        LastName = table.Column<string>(type: "text", nullable: false),
                        Name = table.Column<string>(type: "text", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Users_Localizations_Office",
                        column: x => x.Office,
                        principalTable: "Localizations",
                        principalColumn: "LocalizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leasing",
                columns: table => new
                {
                    LeaseId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonResponsibleId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leasing", x => x.LeaseId);
                    table.ForeignKey(
                        name: "FK_Leasing_AdministrationUser_PersonResponsibleId",
                        column: x => x.PersonResponsibleId,
                        principalTable: "AdministrationUser",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "text", nullable: false),
                    PrimaryUserId = table.Column<string>(type: "text", nullable: false),
                    PrimaryLocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    EngineSize = table.Column<float>(type: "real", nullable: false),
                    Fuel = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    LeasedIn = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDriveable = table.Column<bool>(type: "boolean", nullable: false),
                    LicensePlate = table.Column<string>(type: "text", nullable: false),
                    Make = table.Column<string>(type: "text", nullable: false),
                    Mileage = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Power = table.Column<int>(type: "integer", nullable: false),
                    Seats = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VIN);
                    table.ForeignKey(
                        name: "FK_Cars_Leasing_LeasedIn",
                        column: x => x.LeasedIn,
                        principalTable: "Leasing",
                        principalColumn: "LeaseId");
                    table.ForeignKey(
                        name: "FK_Cars_Localizations_PrimaryLocationId",
                        column: x => x.PrimaryLocationId,
                        principalTable: "Localizations",
                        principalColumn: "LocalizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Users_PrimaryUserId",
                        column: x => x.PrimaryUserId,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarIdentifier = table.Column<string>(type: "text", nullable: false),
                    UserIdentifier = table.Column<string>(type: "text", nullable: false),
                    DestinationCity = table.Column<string>(type: "text", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    StartCity = table.Column<string>(type: "text", nullable: false),
                    ReservationDates_EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReservationDates_StartDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarIdentifier",
                        column: x => x.CarIdentifier,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserIdentifier",
                        column: x => x.UserIdentifier,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReservationOrigin = table.Column<Guid>(type: "uuid", nullable: false),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    FuelConsumed = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripReport_Reservations_ReservationOrigin",
                        column: x => x.ReservationOrigin,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Defect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    CarStop = table.Column<bool>(type: "boolean", nullable: false),
                    TripReportId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Defect_TripReport_TripReportId",
                        column: x => x.TripReportId,
                        principalTable: "TripReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "City", "Country" },
                values: new object[,]
                {
                    { new Guid("1b3d5a6f-7e4c-44d9-a2b1-6c3f8e7a9d64"), "Madrid", "Spain" },
                    { new Guid("2e4f1b3d-8a7c-43c6-9e1f-5a6b7d2c1a46"), "Paris", "France" },
                    { new Guid("3f5a8f1e-2b3c-4a6d-9e2f-7d3b2c1a5f01"), "New York", "USA" },
                    { new Guid("4e7b6d2c-3a1f-49e8-b5a2-7c8d9e1f3a73"), "Rome", "Italy" },
                    { new Guid("5f2e3d1b-9a7c-4c8e-b6d2-1a3f4e7b5c28"), "Sydney", "Australia" },
                    { new Guid("6a5d4c3b-1f9e-44a7-82d3-5e4f1c2b7a19"), "Birmingham", "UK" },
                    { new Guid("7c9b5a3e-d2f1-41e6-9a3c-2b4d5f6a8e16"), "Manchester", "UK" },
                    { new Guid("8f1e3a7b-2d4c-4c9a-8e6d-3f5b1a2c7e55"), "Berlin", "Germany" },
                    { new Guid("91a7d6c3-2f1b-4e5c-a3d2-8c7b6a5f4e03"), "London", "UK" },
                    { new Guid("9e1f3a6d-5b2c-43d8-8a7c-1b6f4e5a7c82"), "Toronto", "Canada" },
                    { new Guid("a5e3c1b2-6f79-4d8e-a1c4-5f2e3b7a9d74"), "Miami", "USA" },
                    { new Guid("b2d3e5f6-78c9-41e2-91a3-3a5c1e2d4f83"), "Chicago", "USA" },
                    { new Guid("c3d2e1f4-7b5a-4a6c-9d8e-2f1b3a5c6e37"), "Melbourne", "Australia" },
                    { new Guid("d9a6e7b4-1c3d-42f5-a8b7-9c3d2f5a6e12"), "Los Angeles", "USA" },
                    { new Guid("e2f5a6c3-9d1b-4e3f-81a7-7b6d4c2f1a95"), "San Francisco", "USA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministrationUser_Office",
                table: "AdministrationUser",
                column: "Office");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_LeasedIn",
                table: "Cars",
                column: "LeasedIn");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PrimaryLocationId",
                table: "Cars",
                column: "PrimaryLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PrimaryUserId",
                table: "Cars",
                column: "PrimaryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Defect_TripReportId",
                table: "Defect",
                column: "TripReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Leasing_PersonResponsibleId",
                table: "Leasing",
                column: "PersonResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarIdentifier",
                table: "Reservations",
                column: "CarIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserIdentifier",
                table: "Reservations",
                column: "UserIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_TripReport_ReservationOrigin",
                table: "TripReport",
                column: "ReservationOrigin");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Office",
                table: "Users",
                column: "Office");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Defect");

            migrationBuilder.DropTable(
                name: "TripReport");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Leasing");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AdministrationUser");

            migrationBuilder.DropTable(
                name: "Localizations");
        }
    }
}

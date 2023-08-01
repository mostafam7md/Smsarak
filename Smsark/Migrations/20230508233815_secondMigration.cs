using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smsark.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apartmentItems");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "apartments",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "NoofBeds",
                table: "apartments",
                newName: "NoOfBeds");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalIdPhoto",
                table: "owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalPhoto",
                table: "owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Smoker",
                table: "customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "LandLine",
                table: "apartments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NoOfBathrooms",
                table: "apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Photos",
                table: "apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Videos",
                table: "apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "WiFi",
                table: "apartments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ResId = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "apartments",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_reservations_RoomId",
                        column: x => x.RoomId,
                        principalTable: "reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedPrice = table.Column<float>(type: "real", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ApartmentId",
                table: "Rooms",
                column: "ApartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "owners");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "owners");

            migrationBuilder.DropColumn(
                name: "NationalIdPhoto",
                table: "owners");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "owners");

            migrationBuilder.DropColumn(
                name: "PersonalPhoto",
                table: "owners");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "owners");

            migrationBuilder.DropColumn(
                name: "City",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "Smoker",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "University",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "LandLine",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "NoOfBathrooms",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "Photos",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "Videos",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "WiFi",
                table: "apartments");

            migrationBuilder.RenameColumn(
                name: "NoOfBeds",
                table: "apartments",
                newName: "NoofBeds");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "apartments",
                newName: "location");

            migrationBuilder.CreateTable(
                name: "apartmentItems",
                columns: table => new
                {
                    ApartmentItemId = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    ResId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartmentItems", x => x.ApartmentItemId);
                    table.ForeignKey(
                        name: "FK_apartmentItems_apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "apartments",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_apartmentItems_reservations_ApartmentItemId",
                        column: x => x.ApartmentItemId,
                        principalTable: "reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apartmentItems_ApartmentId",
                table: "apartmentItems",
                column: "ApartmentId");
        }
    }
}

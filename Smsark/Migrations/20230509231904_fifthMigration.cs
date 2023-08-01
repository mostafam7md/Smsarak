using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smsark.Migrations
{
    /// <inheritdoc />
    public partial class fifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

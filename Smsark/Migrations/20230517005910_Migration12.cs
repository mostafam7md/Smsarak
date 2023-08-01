using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smsark.Migrations
{
    /// <inheritdoc />
    public partial class Migration12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalPhoto",
                table: "owners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonalPhoto",
                table: "owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

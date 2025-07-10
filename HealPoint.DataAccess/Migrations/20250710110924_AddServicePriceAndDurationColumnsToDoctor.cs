using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealPoint.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddServicePriceAndDurationColumnsToDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceDuration",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicePrice",
                table: "Doctors",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceDuration",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ServicePrice",
                table: "Doctors");
        }
    }
}

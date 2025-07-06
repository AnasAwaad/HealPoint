using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealPoint.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorOperationModelColumnToDoctorAndImageUrlToService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Service",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OperationMode",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "OperationMode",
                table: "Doctors");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealPoint.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ConvertRelationBetweenDoctorAndServiceToOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_AspNetUsers_CreatedById",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_AspNetUsers_LastUpdatedById",
                table: "Service");

            migrationBuilder.DropTable(
                name: "DoctorService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameIndex(
                name: "IX_Service_LastUpdatedById",
                table: "Services",
                newName: "IX_Services_LastUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Service_CreatedById",
                table: "Services",
                newName: "IX_Services_CreatedById");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ServiceId",
                table: "Doctors",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Services_ServiceId",
                table: "Doctors",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_CreatedById",
                table: "Services",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_LastUpdatedById",
                table: "Services",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Services_ServiceId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_CreatedById",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_LastUpdatedById",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ServiceId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameIndex(
                name: "IX_Services_LastUpdatedById",
                table: "Service",
                newName: "IX_Service_LastUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CreatedById",
                table: "Service",
                newName: "IX_Service_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DoctorService",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastUpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorService", x => new { x.DoctorId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_DoctorService_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorService_AspNetUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorService_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorService_CreatedById",
                table: "DoctorService",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorService_LastUpdatedById",
                table: "DoctorService",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorService_ServiceId",
                table: "DoctorService",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AspNetUsers_CreatedById",
                table: "Service",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AspNetUsers_LastUpdatedById",
                table: "Service",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

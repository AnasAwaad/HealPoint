using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealPoint.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceTableAndDoctorServiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastUpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Service_AspNetUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoctorService",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Service_CreatedById",
                table: "Service",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Service_LastUpdatedById",
                table: "Service",
                column: "LastUpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorService");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}

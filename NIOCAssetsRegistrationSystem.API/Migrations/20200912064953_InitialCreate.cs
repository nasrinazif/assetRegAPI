using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NIOCAssetsRegistrationSystem.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapCoordinatesAccuracies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapCoordinatesAccuracies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapFormats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnershipDocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipDocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    UserTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompaniesPropertyInquiries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyTitle = table.Column<string>(nullable: true),
                    ArenaArea = table.Column<decimal>(nullable: true),
                    OwnershipDocument = table.Column<bool>(nullable: true),
                    ExistingMap = table.Column<bool>(nullable: true),
                    ExistingBuilding = table.Column<bool>(nullable: true),
                    BuildingArea = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LatestChanges = table.Column<DateTime>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    OwnershipDocumentTypeId = table.Column<int>(nullable: true),
                    MapFormatId = table.Column<int>(nullable: true),
                    MapCoordinatesAccuracyId = table.Column<int>(nullable: true),
                    BuildingTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesPropertyInquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompaniesPropertyInquiries_BuildingTypes_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesPropertyInquiries_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesPropertyInquiries_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesPropertyInquiries_MapCoordinatesAccuracies_MapCoordinatesAccuracyId",
                        column: x => x.MapCoordinatesAccuracyId,
                        principalTable: "MapCoordinatesAccuracies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesPropertyInquiries_MapFormats_MapFormatId",
                        column: x => x.MapFormatId,
                        principalTable: "MapFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesPropertyInquiries_OwnershipDocumentTypes_OwnershipDocumentTypeId",
                        column: x => x.OwnershipDocumentTypeId,
                        principalTable: "OwnershipDocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesPropertyInquiries_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesPropertyInquiries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Confirmations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfirmDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confirmations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Confirmations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Confirmations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesPropertyInquiries_BuildingTypeId",
                table: "CompaniesPropertyInquiries",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesPropertyInquiries_CityId",
                table: "CompaniesPropertyInquiries",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesPropertyInquiries_CompanyId",
                table: "CompaniesPropertyInquiries",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesPropertyInquiries_MapCoordinatesAccuracyId",
                table: "CompaniesPropertyInquiries",
                column: "MapCoordinatesAccuracyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesPropertyInquiries_MapFormatId",
                table: "CompaniesPropertyInquiries",
                column: "MapFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesPropertyInquiries_OwnershipDocumentTypeId",
                table: "CompaniesPropertyInquiries",
                column: "OwnershipDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesPropertyInquiries_ProvinceId",
                table: "CompaniesPropertyInquiries",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesPropertyInquiries_UserId",
                table: "CompaniesPropertyInquiries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_CompanyId",
                table: "Confirmations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_UserId",
                table: "Confirmations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesPropertyInquiries");

            migrationBuilder.DropTable(
                name: "Confirmations");

            migrationBuilder.DropTable(
                name: "BuildingTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "MapCoordinatesAccuracies");

            migrationBuilder.DropTable(
                name: "MapFormats");

            migrationBuilder.DropTable(
                name: "OwnershipDocumentTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}

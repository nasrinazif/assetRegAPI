using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NIOCAssetsRegistrationSystem.API.Migrations
{
    public partial class UploadedFileLatLongAddedToComPropInq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "CompaniesPropertyInquiries",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "CompaniesPropertyInquiries",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "UploadedFile",
                table: "CompaniesPropertyInquiries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "CompaniesPropertyInquiries");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "CompaniesPropertyInquiries");

            migrationBuilder.DropColumn(
                name: "UploadedFile",
                table: "CompaniesPropertyInquiries");
        }
    }
}

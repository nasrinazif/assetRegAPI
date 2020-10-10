using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NIOCAssetsRegistrationSystem.API.Migrations
{
    public partial class FilePathAddedToFileUploads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadedFile",
                table: "FileUploads");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "FileUploads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "FileUploads");

            migrationBuilder.AddColumn<byte[]>(
                name: "UploadedFile",
                table: "FileUploads",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}

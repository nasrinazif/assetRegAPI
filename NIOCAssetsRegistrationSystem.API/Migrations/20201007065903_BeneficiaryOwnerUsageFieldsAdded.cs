using Microsoft.EntityFrameworkCore.Migrations;

namespace NIOCAssetsRegistrationSystem.API.Migrations
{
    public partial class BeneficiaryOwnerUsageFieldsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryId",
                table: "CompaniesPropertyInquiries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "CompaniesPropertyInquiries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usage",
                table: "CompaniesPropertyInquiries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesPropertyInquiries_BeneficiaryId",
                table: "CompaniesPropertyInquiries",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesPropertyInquiries_OwnerId",
                table: "CompaniesPropertyInquiries",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesPropertyInquiries_Beneficiaries_BeneficiaryId",
                table: "CompaniesPropertyInquiries",
                column: "BeneficiaryId",
                principalTable: "Beneficiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesPropertyInquiries_Owners_OwnerId",
                table: "CompaniesPropertyInquiries",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesPropertyInquiries_Beneficiaries_BeneficiaryId",
                table: "CompaniesPropertyInquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesPropertyInquiries_Owners_OwnerId",
                table: "CompaniesPropertyInquiries");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_CompaniesPropertyInquiries_BeneficiaryId",
                table: "CompaniesPropertyInquiries");

            migrationBuilder.DropIndex(
                name: "IX_CompaniesPropertyInquiries_OwnerId",
                table: "CompaniesPropertyInquiries");

            migrationBuilder.DropColumn(
                name: "BeneficiaryId",
                table: "CompaniesPropertyInquiries");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "CompaniesPropertyInquiries");

            migrationBuilder.DropColumn(
                name: "Usage",
                table: "CompaniesPropertyInquiries");
        }
    }
}

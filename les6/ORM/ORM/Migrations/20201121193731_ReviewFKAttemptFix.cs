using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM.Migrations
{
    public partial class ReviewFKAttemptFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Company_CompanyOrganisationId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_CompanyOrganisationId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "CompanyOrganisationId",
                table: "Review");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyOrganisationId",
                table: "Review",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_CompanyOrganisationId",
                table: "Review",
                column: "CompanyOrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Company_CompanyOrganisationId",
                table: "Review",
                column: "CompanyOrganisationId",
                principalTable: "Company",
                principalColumn: "Organisation_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

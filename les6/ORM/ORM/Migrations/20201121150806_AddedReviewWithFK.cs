using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM.Migrations
{
    public partial class AddedReviewWithFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_CompanyOrganisationId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CompanyOrganisationId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CompanyOrganisationId",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Review_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    OrganisationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompanyOrganisationId = table.Column<int>(type: "INTEGER", nullable: true),
                    SequenceNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductOrganisationId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductSequenceNumber = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_Review_Company_CompanyOrganisationId",
                        column: x => x.CompanyOrganisationId,
                        principalTable: "Company",
                        principalColumn: "Organisation_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Product_ProductOrganisationId_ProductSequenceNumber",
                        columns: x => new { x.ProductOrganisationId, x.ProductSequenceNumber },
                        principalTable: "Product",
                        principalColumns: new[] { "OrganisationId", "SequenceNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_CompanyOrganisationId",
                table: "Review",
                column: "CompanyOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductOrganisationId_ProductSequenceNumber",
                table: "Review",
                columns: new[] { "ProductOrganisationId", "ProductSequenceNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_OrganisationId",
                table: "Product",
                column: "OrganisationId",
                principalTable: "Company",
                principalColumn: "Organisation_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_OrganisationId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.AddColumn<int>(
                name: "CompanyOrganisationId",
                table: "Product",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CompanyOrganisationId",
                table: "Product",
                column: "CompanyOrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_CompanyOrganisationId",
                table: "Product",
                column: "CompanyOrganisationId",
                principalTable: "Company",
                principalColumn: "Organisation_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

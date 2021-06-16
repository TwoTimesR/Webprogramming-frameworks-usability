using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM.Migrations
{
    public partial class ReviewFKAttemptFix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Product_OrganisationId_SequenceNumber",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_OrganisationId_SequenceNumber",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "SequenceNumber",
                table: "Review",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Review",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductOrganisationId",
                table: "Review",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductSequenceNumber",
                table: "Review",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductOrganisationId_ProductSequenceNumber",
                table: "Review",
                columns: new[] { "ProductOrganisationId", "ProductSequenceNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Product_ProductOrganisationId_ProductSequenceNumber",
                table: "Review",
                columns: new[] { "ProductOrganisationId", "ProductSequenceNumber" },
                principalTable: "Product",
                principalColumns: new[] { "OrganisationId", "SequenceNumber" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Product_ProductOrganisationId_ProductSequenceNumber",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ProductOrganisationId_ProductSequenceNumber",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ProductOrganisationId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ProductSequenceNumber",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "SequenceNumber",
                table: "Review",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "OrganisationId",
                table: "Review",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Review_OrganisationId_SequenceNumber",
                table: "Review",
                columns: new[] { "OrganisationId", "SequenceNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Product_OrganisationId_SequenceNumber",
                table: "Review",
                columns: new[] { "OrganisationId", "SequenceNumber" },
                principalTable: "Product",
                principalColumns: new[] { "OrganisationId", "SequenceNumber" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}

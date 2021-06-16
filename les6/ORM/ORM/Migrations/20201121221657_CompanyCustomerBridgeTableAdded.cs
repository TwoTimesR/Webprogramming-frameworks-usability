using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM.Migrations
{
    public partial class CompanyCustomerBridgeTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCustomer_Company_CompaniesOrganisationId",
                table: "CompanyCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCustomer_Customer_CustomersCustomerId",
                table: "CompanyCustomer");

            migrationBuilder.RenameColumn(
                name: "CustomersCustomerId",
                table: "CompanyCustomer",
                newName: "Customer_Id");

            migrationBuilder.RenameColumn(
                name: "CompaniesOrganisationId",
                table: "CompanyCustomer",
                newName: "Organisation_Id");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCustomer_CustomersCustomerId",
                table: "CompanyCustomer",
                newName: "IX_CompanyCustomer_Customer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCustomer_Company_Organisation_Id",
                table: "CompanyCustomer",
                column: "Organisation_Id",
                principalTable: "Company",
                principalColumn: "Organisation_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCustomer_Customer_Customer_Id",
                table: "CompanyCustomer",
                column: "Customer_Id",
                principalTable: "Customer",
                principalColumn: "Customer_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCustomer_Company_Organisation_Id",
                table: "CompanyCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCustomer_Customer_Customer_Id",
                table: "CompanyCustomer");

            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "CompanyCustomer",
                newName: "CustomersCustomerId");

            migrationBuilder.RenameColumn(
                name: "Organisation_Id",
                table: "CompanyCustomer",
                newName: "CompaniesOrganisationId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCustomer_Customer_Id",
                table: "CompanyCustomer",
                newName: "IX_CompanyCustomer_CustomersCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCustomer_Company_CompaniesOrganisationId",
                table: "CompanyCustomer",
                column: "CompaniesOrganisationId",
                principalTable: "Company",
                principalColumn: "Organisation_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCustomer_Customer_CustomersCustomerId",
                table: "CompanyCustomer",
                column: "CustomersCustomerId",
                principalTable: "Customer",
                principalColumn: "Customer_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

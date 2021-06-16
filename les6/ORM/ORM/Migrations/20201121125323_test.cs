using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCustomer_Customers_CustomersCustomerId",
                table: "CompanyCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCustomer_Organisations_CompaniesOrganisationId",
                table: "CompanyCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Organisations_OrganisationId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Organisations_CompanyOrganisationId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organisations",
                table: "Organisations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "Solvability",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "StockPrice",
                table: "Organisations");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Owner");

            migrationBuilder.RenameTable(
                name: "Organisations",
                newName: "Organisation");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "SequenceNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CompanyOrganisationId",
                table: "Product",
                newName: "IX_Product_CompanyOrganisationId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Owner",
                newName: "Owner_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Owners_OrganisationId",
                table: "Owner",
                newName: "IX_Owner_OrganisationId");

            migrationBuilder.RenameColumn(
                name: "OrganisationId",
                table: "Organisation",
                newName: "Organisation_Id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customer",
                newName: "Customer_Id");

            migrationBuilder.AlterColumn<int>(
                name: "SequenceNumber",
                table: "Product",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                columns: new[] { "OrganisationId", "SequenceNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owner",
                table: "Owner",
                column: "Owner_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organisation",
                table: "Organisation",
                column: "Organisation_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Customer_Id");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Organisation_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StockPrice = table.Column<double>(type: "REAL", nullable: false),
                    Solvability = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Organisation_Id);
                    table.ForeignKey(
                        name: "FK_Company_Organisation_Organisation_Id",
                        column: x => x.Organisation_Id,
                        principalTable: "Organisation",
                        principalColumn: "Organisation_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NonProfit",
                columns: table => new
                {
                    Organisation_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Goal = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonProfit", x => x.Organisation_Id);
                    table.ForeignKey(
                        name: "FK_NonProfit_Organisation_Organisation_Id",
                        column: x => x.Organisation_Id,
                        principalTable: "Organisation",
                        principalColumn: "Organisation_Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_Organisation_OrganisationId",
                table: "Owner",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Organisation_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_CompanyOrganisationId",
                table: "Product",
                column: "CompanyOrganisationId",
                principalTable: "Company",
                principalColumn: "Organisation_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCustomer_Company_CompaniesOrganisationId",
                table: "CompanyCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCustomer_Customer_CustomersCustomerId",
                table: "CompanyCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Owner_Organisation_OrganisationId",
                table: "Owner");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_CompanyOrganisationId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "NonProfit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owner",
                table: "Owner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organisation",
                table: "Organisation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Owner",
                newName: "Owners");

            migrationBuilder.RenameTable(
                name: "Organisation",
                newName: "Organisations");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameColumn(
                name: "SequenceNumber",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CompanyOrganisationId",
                table: "Products",
                newName: "IX_Products_CompanyOrganisationId");

            migrationBuilder.RenameColumn(
                name: "Owner_Id",
                table: "Owners",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Owner_OrganisationId",
                table: "Owners",
                newName: "IX_Owners_OrganisationId");

            migrationBuilder.RenameColumn(
                name: "Organisation_Id",
                table: "Organisations",
                newName: "OrganisationId");

            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Organisations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Organisations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "Organisations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Solvability",
                table: "Organisations",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StockPrice",
                table: "Organisations",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organisations",
                table: "Organisations",
                column: "OrganisationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCustomer_Customers_CustomersCustomerId",
                table: "CompanyCustomer",
                column: "CustomersCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCustomer_Organisations_CompaniesOrganisationId",
                table: "CompanyCustomer",
                column: "CompaniesOrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Organisations_OrganisationId",
                table: "Owners",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Organisations_CompanyOrganisationId",
                table: "Products",
                column: "CompanyOrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyCustomer",
                columns: table => new
                {
                    CompaniesOrganisationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomersCustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCustomer", x => new { x.CompaniesOrganisationId, x.CustomersCustomerId });
                    table.ForeignKey(
                        name: "FK_CompanyCustomer_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCustomer_Organisations_CompaniesOrganisationId",
                        column: x => x.CompaniesOrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCustomer_CustomersCustomerId",
                table: "CompanyCustomer",
                column: "CustomersCustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyCustomer");
        }
    }
}

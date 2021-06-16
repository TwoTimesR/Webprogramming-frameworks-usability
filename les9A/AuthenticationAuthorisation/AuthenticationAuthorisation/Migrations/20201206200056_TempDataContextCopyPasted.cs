using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationAuthorisation.Migrations
{
    public partial class TempDataContextCopyPasted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToetsResultaat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentNaam = table.Column<string>(type: "TEXT", nullable: true),
                    Cijfer = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToetsResultaat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToetsResultaat");
        }
    }
}

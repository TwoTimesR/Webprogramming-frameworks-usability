using Microsoft.EntityFrameworkCore.Migrations;

namespace Validation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Voornaam = table.Column<string>(type: "TEXT", nullable: true),
                    Achternaam = table.Column<string>(type: "TEXT", nullable: true),
                    Woonplaats = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Opleiding = table.Column<string>(type: "TEXT", nullable: true),
                    Studiepunten = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Student_ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentVriend",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Vriend_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentVriend", x => new { x.Student_ID, x.Vriend_ID });
                    table.ForeignKey(
                        name: "FK_StudentVriend_Student_Vriend_ID",
                        column: x => x.Vriend_ID,
                        principalTable: "Student",
                        principalColumn: "Student_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentVriend_Vriend_ID",
                table: "StudentVriend",
                column: "Vriend_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentVriend");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}

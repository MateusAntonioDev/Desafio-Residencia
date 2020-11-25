using Microsoft.EntityFrameworkCore.Migrations;

namespace Dinda.Migrations
{
    public partial class TabelaMadrinhas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Madrinhas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConhecimentosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Madrinhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Madrinhas_Conhecimentos_ConhecimentosId",
                        column: x => x.ConhecimentosId,
                        principalTable: "Conhecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Madrinhas_ConhecimentosId",
                table: "Madrinhas",
                column: "ConhecimentosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Madrinhas");
        }
    }
}

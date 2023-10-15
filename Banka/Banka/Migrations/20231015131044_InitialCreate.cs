using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banka.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TekuciRacuni",
                columns: table => new
                {
                    IBAN = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    StanjeRacuna = table.Column<float>(type: "REAL", nullable: false),
                    RaspoloziviIznos = table.Column<float>(type: "REAL", nullable: false),
                    RezerviraniIznos = table.Column<float>(type: "REAL", nullable: false),
                    LimitUplata = table.Column<float>(type: "REAL", nullable: false),
                    LimitIsplata = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TekuciRacuni", x => x.IBAN);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TekuciRacuni");
        }
    }
}

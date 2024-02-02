using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProduMan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lp = table.Column<int>(type: "int", nullable: false),
                    NrZamowienia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZamowionaIlosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IloscDoZmontowania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZmontowanaIlosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UwagiSmd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UwagiTht = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UwagiSzablon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poziom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tydzien = table.Column<int>(type: "int", nullable: false),
                    DzienTygodnia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NowyProdukt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OsobaPrzyjmujacaZlecenie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Traceability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pasta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Komponenty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    THT = table.Column<bool>(type: "bit", nullable: false),
                    AOI = table.Column<bool>(type: "bit", nullable: false),
                    Mycie = table.Column<bool>(type: "bit", nullable: false),
                    Testowanie = table.Column<bool>(type: "bit", nullable: false),
                    Programowanie = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

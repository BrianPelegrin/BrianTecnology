using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrianTecnology.Migrations
{
    public partial class migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CATEGORI__A3C02A102B3C74BF", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTOS",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCTO__0988921059064F42", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK__PRODUCTOS__IdCat__267ABA7A",
                        column: x => x.IdCategoria,
                        principalTable: "CATEGORIA",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTOS_IdCategoria",
                table: "PRODUCTOS",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTOS");

            migrationBuilder.DropTable(
                name: "CATEGORIA");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCatalog.Migrations
{
    public partial class CreateCategories : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Categories\" (\"Name\", \"ImageUrl\") VALUES ('Bebidas', 'bebidas.jpg')");
            migrationBuilder.Sql("INSERT INTO \"Categories\" (\"Name\", \"ImageUrl\") VALUES ('Lanches', 'lanches.jpg')");
            migrationBuilder.Sql("INSERT INTO \"Categories\" (\"Name\", \"ImageUrl\") VALUES ('Sobremesas', 'sobremesas.jpg')");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Categogies\"");
        }
    }
}

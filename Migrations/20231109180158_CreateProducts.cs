using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalog.Migrations
{
    /// <inheritdoc />
    public partial class CreateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Products\" (\"Name\", \"Description\", \"ImageUrl\", \"Price\", \"Stock\", \"CreatedAt\", \"CategoryId\")" 
            + "VALUES ('Coca-Cola', 'Refrigerante de Cola 350ml', 'cocacola.jpg', 5.45, 50, now(), 1)");
            migrationBuilder.Sql("INSERT INTO \"Products\" (\"Name\", \"Description\", \"ImageUrl\", \"Price\", \"Stock\", \"CreatedAt\", \"CategoryId\")" 
            + "VALUES ('Lanche de Atum', 'Lanche de atum com maionese', 'lache-atum.jpg', 8.50, 10, now(), 2)");
            migrationBuilder.Sql("INSERT INTO \"Products\" (\"Name\", \"Description\", \"ImageUrl\", \"Price\", \"Stock\", \"CreatedAt\", \"CategoryId\")" 
            + "VALUES ('Pudim', 'Pudim de leite condensado 100g','pudim.jpg', 0.75, 20, now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Products\"");
        }
    }
}

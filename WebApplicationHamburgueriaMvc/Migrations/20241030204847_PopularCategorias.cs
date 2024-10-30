using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationHamburgueriaMvc.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " +
                "VALUES ('Normal', 'Lanche saboroso, feito com ingredientes tradicionais e selecionados para garantir qualidade e sabor.')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " +
                "VALUES ('Natural', 'Lanche leve e saudável, preparado com ingredientes integrais, frescos e naturais, perfeito para quem busca uma alimentação balanceada.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}

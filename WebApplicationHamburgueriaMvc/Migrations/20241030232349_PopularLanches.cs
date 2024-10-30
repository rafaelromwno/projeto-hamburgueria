using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationHamburgueriaMvc.Migrations
{
    public partial class PopularLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) " +
                "VALUES(1,'Pão, hambúrguer, ovo, presunto, queijo e batata palha','Pão de hambúrguer macio, com hambúrguer suculento e ovo frito; presunto e queijo de alta qualidade, tudo coroado com batata palha crocante para um sabor irresistível.',1, 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', 0 ,'Cheese Salada', 12.50)");

            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) " +
                "VALUES(1,'Pão, presunto, mussarela e tomate','Pão francês dourado na chapa, com presunto e mussarela derretidos e uma camada de tomate fresco. Preparado com carinho para um lanche simples e delicioso.',1,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',0,'Misto Quente', 8.00)");

            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) " +
                "VALUES(1,'Pão, hambúrguer, presunto, mussarela e batata palha','Pão de hambúrguer especial com hambúrguer artesanal, presunto suculento e mussarela cremosa, acompanhados por batata palha para um toque crocante.',1,'http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg',0,'Cheese Burger', 11.00)");

            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) " +
                "VALUES(2,'Pão Integral, queijo branco, peito de peru, cenoura, alface, iogurte','Lanche leve e saudável com pão integral, queijo branco fresco, peito de peru magro, cenoura ralada e alface crocante, finalizado com iogurte natural. Ideal para quem busca sabor e leveza.',1,'http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg',1,'Lanche Natural Peito Peru', 15.00)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}

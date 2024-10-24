namespace WebApplicationHamburgueriaMvc.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }

        //Propriedade de Navegação -> Define o relacionamento entre as entidades (Convenção do Entity Framework Core)
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }


    }
}

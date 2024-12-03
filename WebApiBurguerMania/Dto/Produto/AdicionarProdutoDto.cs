using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiBurguerMania.Dto.Produto
{
    public class AdicionarProdutoDto
    {

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public String PathImagem { get; set; }
        public double Preco { get; set; }
        public string DescricaoBasica { get; set; }
        public string DescricaoCompleta { get; set; }
    }
}

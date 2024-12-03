using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiBurguerMania.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public string Nome { get; set;}
        public String PathImagem { get; set; }
        public double Preco {  get; set; }
        public string DescricaoBasica {  get; set; }
        public string DescricaoCompleta { get; set; }

        [JsonIgnore]
        public CategoriaModel Categoria { get; set; }

        [JsonIgnore]
        public ICollection<ItemPedidoModel> ItensPedido { get; set; }

    }
}

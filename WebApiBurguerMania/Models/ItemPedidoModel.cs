using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiBurguerMania.Models
{
    public class ItemPedidoModel
    {
        [Key]
        public int Id { get; set;}

        [ForeignKey("PedidoId")]
        public int PedidoId { get; set;}

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set;}

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        public int Quantidade { get; set;}
        public double PrecoUnitario { get; set;}

        [JsonIgnore]
        public PedidoModel Pedido { get; set; }

        [JsonIgnore]
        public ProdutoModel Produto { get; set; }
    }
}

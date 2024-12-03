using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiBurguerMania.Dto.ItemPedido
{
    public class EditarItemPedidoDto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PedidoId")]
        public int PedidoId { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
    }
}

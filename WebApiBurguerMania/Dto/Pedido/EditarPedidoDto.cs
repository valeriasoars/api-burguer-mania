using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiBurguerMania.Dto.Pedido
{
    public class EditarPedidoDto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public double Valor { get; set; }
        public DateTime DataPedido { get; set; }

    }
}

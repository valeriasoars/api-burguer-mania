using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiBurguerMania.Dto.Pedido
{
    public class AdicionarPedidoDto
    {
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public double Valor { get; set; }
        public DateTime DataPedido { get; set; }

    }
}

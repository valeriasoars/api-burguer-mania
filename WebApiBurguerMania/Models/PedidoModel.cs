using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiBurguerMania.Models
{
    public class PedidoModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public double Valor { get; set; }
        public DateTime DataPedido { get; set; }

        [JsonIgnore]
        public UsuarioModel Usuario { get; set; }

        [JsonIgnore]
        public ICollection<ItemPedidoModel> ItensPedido { get; set; }

    }
}

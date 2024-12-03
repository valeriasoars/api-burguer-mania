using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiBurguerMania.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public string Email {  get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }

        [JsonIgnore]
        public ICollection<PedidoModel> Pedidos { get; set; }
    }
}

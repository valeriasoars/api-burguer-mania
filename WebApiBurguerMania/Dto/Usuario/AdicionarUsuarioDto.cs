using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Dto.Usuario
{
    public class AdicionarUsuarioDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApiBurguerMania.Dto.Categoria
{
    public class EditarCategoriaDto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string PathImagem { get; set; }
    }
}

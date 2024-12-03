using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiBurguerMania.Models
{
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao {  get; set; }
        public string PathImagem { get; set; }

        [JsonIgnore]
        public ICollection<ProdutoModel> Produtos { get; set; }
    }
}

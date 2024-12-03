using WebApiBurguerMania.Dto.Categoria;
using WebApiBurguerMania.Dto.Usuario;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Categoria
{
    public interface ICategoria
    {
        Task<ResponseModel<List<CategoriaModel>>> ListarCategorias();
        Task<ResponseModel<CategoriaModel>> BuscarCategoriaPorId(int idCategoria);
        Task<ResponseModel<List<CategoriaModel>>> AdicionarCategoria(AdicionarCategoriaDto adicionarCategoriaDto);
        Task<ResponseModel<List<CategoriaModel>>> EditarCategoria(EditarCategoriaDto editarCategoriaDto);
        Task<ResponseModel<List<CategoriaModel>>> ExcluirCategoria(int idCategoria);


    }
}
